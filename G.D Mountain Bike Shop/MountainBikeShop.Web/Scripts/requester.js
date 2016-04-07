var Requester = (function () {
    function Requester() {
    }
    Requester.prototype.makeRequest = function (method, url, data) {
        var token,
            defer = Q.defer(),
            options = {
                method: method,
                url: url,
                success: function (data) {
                    defer.resolve(data);
                },
                error: function (error) {
                    defer.reject(error);
                }
            };
        if (data !== null) {
            options.data = JSON.stringify(data);
            options.headers = {
                'Content-Type': 'application/json'
            };
        }
        $.ajax(options);

        return defer.promise;
    };

    return Requester
    
})();