window.blazorSpeech = {
  
    recognizeOnce: (lang) => {
        return new Promise((resolve, reject) => {
            const Rec = window.SpeechRecognition || window.webkitSpeechRecognition;
            if (!Rec) return reject("SpeechRecognition nicht unterstützt");
            const r = new Rec();
            r.lang = lang;
            r.interimResults = false;
            r.continuous = false;
            r.maxAlternatives = 1;
            r.onresult = e => resolve(e.results[0][0].transcript);
            r.onerror = e => reject(e.error || e.message);
            r.start();
        });
    },

    startContinuous: (lang, dotNetRef) => {
        const Rec = window.SpeechRecognition || window.webkitSpeechRecognition;
        if (!Rec) {
            dotNetRef.invokeMethodAsync("NotifyError", "SpeechRecognition nicht unterstützt");
            return;
        }
        window._blazorRec = new Rec();
        const r = window._blazorRec;
        r.lang = lang;
        r.interimResults = true;
        r.continuous = true;
        r.maxAlternatives = 1;

        r.onresult = e => {
            let interim = "", final = "";
            for (let i = e.resultIndex; i < e.results.length; i++) {
                const res = e.results[i];
                if (res.isFinal) final += res[0].transcript;
                else interim += res[0].transcript;
            }
            dotNetRef.invokeMethodAsync("NotifyRecognized", interim, false);
            if (final) dotNetRef.invokeMethodAsync("NotifyRecognized", final, true);
        };
        r.onerror = e => dotNetRef.invokeMethodAsync("NotifyError", e.error || e.message);
        r.start();
    },
    stopContinuous: () => {
        if (window._blazorRec) {
            window._blazorRec.stop();
            delete window._blazorRec;
        }
    },

    speakText: (text, lang) => {
        if (!window.speechSynthesis) return;
        const u = new SpeechSynthesisUtterance(text);
        u.lang = lang;
        window.speechSynthesis.speak(u);
    }
};