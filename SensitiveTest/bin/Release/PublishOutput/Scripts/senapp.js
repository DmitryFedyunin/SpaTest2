// Основная логик
senapp = new Vue({
    el: '#senapp',
    data: {
        step: 1,//начало
        items: [],// ответы экстрасенсов
        userValue: 0,//загаданное число
        queryHash: '',//id теста
        errorMessage: ''//сообщение об ошибке
    },
    methods:
        {
            // запуск
            startTest: function () {
                // переход на 2 шаг
                senapp.step = 2;

                // получ ответы экстрасенсов
                $.get("/api/values", function (data) {                    
                    senapp.items = data.items;
                    senapp.queryHash = data.queryHash;                    
                });
            },

            checkValue: function () {
                $.post("/api/values", { value: senapp.userValue, queryHash: senapp.queryHash }, function (data) {
                    $.cookie("userHash", data.userHash);
                    senapp.errorMessage = data.errorMessage;
                    
                    // обработчик ошибки
                    if (senapp.errorMessage == null) {
                        senapp.userValue = 0;
                        senlist.updateSensitives();
                        answerlist.updateAnswerList();
                        senapp.step = 1;
                    }

                });
            }
        }
});


// список экстр
senlist = new Vue({
    el: '#senlist',
    data: {
        items: [],
        answers: [],//история экстрасенсов
        answerHash: ''//ид
    },
    methods: {
        updateSensitives: function () {
            $.get("/api/sensitive", function (data) {
                senlist.items = data.items;
            });
        },
        
        sensitiveInfo: function (sHash) {
            if (senlist.answerHash == sHash) {
                senlist.answerHash = '';
            }
            else {
                $.get("/api/sensitive/", { id: sHash }, function (data) {
                    senlist.answers = data.answers;
                    senlist.answerHash = data.hash;
                });
            }
        }
    }
});

// отвты пользователя
answerlist = new Vue({
    el: '#answerlist',
    data: {
        items: []// список ответов
    },
    methods: {
        // обновление ответов пользов
        updateAnswerList: function () {
            $.get("/api/answer", function (data) {
                answerlist.items = data.items;
            });
        }
    }
});

senlist.updateSensitives();
answerlist.updateAnswerList();