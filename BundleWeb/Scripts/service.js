const service = function () {

    const sendRequest = (method, url, request) => {
        return new Promise(function (resolve, reject) {

            var xhr = new XMLHttpRequest();
            xhr.open(method, url);
            xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8');
            xhr.onload = function () {

                if (this.status = 200) {
                    resolve(xhr.response);
                } else {
                    reject({
                        status: this.status,
                        statusText: xhr.statusText
                    });
                }
            };

            xhr.onerror = function () {
                reject({
                    status: this.status,
                    statusText: xhr.statusText
                });
            };

            xhr.send(JSON.stringify(request));
        });
    };

    const getProducts = (request) => {
        return sendRequest('POST', '/Main/GetProducts', request);
    };

    const getBundle = (request) => {
        return sendRequest('POST', '/Main/GetBundle', request);
    };

    const deleteProduct = (request) => {
        return sendRequest('POST', '/Main/DeleteProduct', request);
    };

    const addProduct = (request) => {
        return sendRequest('POST', '/Main/AddProduct', request);
    }

    return {
        getProducts: getProducts,
        getBundle: getBundle,
        deleteProduct: deleteProduct,
        addProduct: addProduct
    };
}();