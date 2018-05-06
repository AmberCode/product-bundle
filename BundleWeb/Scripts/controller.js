const main = function () {
    
    const hideBundleDiv = () => {
        document.getElementById('bundleDiv').style.display = 'none';
    };

    const showBundleDiv = () => {
        document.getElementById('bundleDiv').style.display = 'block'; 
    };

    const clearBundleTable = () => {
        const table = document.getElementById("bundleTable");
        for (let i = table.rows.length - 1; i > 0; i--) {
            table.deleteRow(i);
        }
    };

    const displayBundleTable = (data) => {
        const table = document.getElementById("bundleTable");

        for (let i = 0; i < data.Products.length; i++) {
            const row = table.insertRow(i + 1);
            row.insertCell(0).innerHTML = data.Products[i].ProductName;      
            row.insertCell(1).innerHTML =
                `<button type='button' name='RemoveButton' data-productid = ${data.Products[i].Id}>Remove</button>`;
        }

        const bundleLabel = document.getElementById("bundleLabel");
        bundleLabel.innerHTML = data.Bundle.BundleName;
        bundleLabel.setAttribute('data-bundleid', data.Bundle.Id);
    };

    const displayProducts = (data) => {
        const sel = document.getElementById('productSelect');

        sel.options.length = 0;

        for (let i = 0; i < data.length; i++) {
            const opt = document.createElement('option');
            opt.innerHTML = data[i].ProductName;
            opt.value = data[i].Id;
            sel.appendChild(opt);
        }
    };

    const init = () => {

        hideBundleDiv();

        document.getElementById('ageInput').addEventListener('change', function () {
            hideBundleDiv();
        });

        document.getElementById('studentCheckbox').addEventListener('change', function () {
            hideBundleDiv();
        });

        document.getElementById('incomeInput').addEventListener('change', function () {
            hideBundleDiv();
        });

        document.getElementById('SearchButton').addEventListener('click', () => {

            hideBundleDiv();
            
            getBundle({
                answer: {
                    Age: utils.convertAge(document.getElementById('ageInput').value),
                    Student: document.getElementById('studentCheckbox').checked,
                    Income: utils.convertIncome(document.getElementById('incomeInput').value)
                }
            });
        });

        document.getElementById('addNewProductButton').addEventListener('click', () => {

            const request = {
                answer: {
                    Age: utils.convertAge(document.getElementById('ageInput').value),
                    Student: document.getElementById('studentCheckbox').checked,
                    Income: utils.convertIncome(document.getElementById('incomeInput').value)
                },
                bundleId: document.getElementById("bundleLabel").getAttribute('data-bundleid'),
                productId: document.getElementById('productSelect').value
            };

            addProduct(request);
        });
    };

    const removeButtonClick = (event) => {
        const targetElement = event.target || event.srcElement;

        let request = {
            answer: {
                Age: utils.convertAge(document.getElementById('ageInput').value),
                Student: document.getElementById('studentCheckbox').checked,
                Income: utils.convertIncome(document.getElementById('incomeInput').value)
            },
            bundleId: bundleLabel.getAttribute('data-bundleid'),
            productId: targetElement.getAttribute('data-productid')
        };

        deleteProduct(request);
    };

    const attachRemoveClick = () => {
        const buttons = document.getElementsByName('RemoveButton');

        for (let i = 0; i < buttons.length; i++) {
            buttons[i].addEventListener('click', function (event) { removeButtonClick(event); }, false);
        }
    };

    const getBundle = (answer) => {

        service.getBundle(answer)
            .then(function (data) {

                const result = JSON.parse(data);

                if (result.Status === true) {

                    clearBundleTable();

                    displayBundleTable(result.Bundle);

                    attachRemoveClick();

                    getProducts(answer);

                    showBundleDiv();

                } else {
                    alert(result.Message);
                }

            })
            .catch(function (err) {
                alert(err);
            });
    };

    const getProducts = (answer) => {

        service.getProducts(answer)
            .then(function (data) {

                const result = JSON.parse(data);
              
                if (result.Status === true) {

                    if (result.Products === null) {
                        alert('Not found');
                    } else {
                        displayProducts(result.Products);
                    }

                } else {
                    alert(result.Message);
                }

            })
            .catch(function (err) {
                alert(err);
            });
    };

    const deleteProduct = (request) => {

        service.deleteProduct(request)
            .then(function (data) {

                const result = JSON.parse(data);

                if (result.Status === true) {

                    clearBundleTable();

                    displayBundleTable(result.Bundle);

                    attachRemoveClick();

                    getProducts(request.answer);

                    showBundleDiv();

                } else {
                    alert(result.Message);
                }

            })
            .catch(function (err) {
                alert(err);
            });
    };

    const addProduct = (request) => {

        service.addProduct(request)
            .then(function (data) {

                const result = JSON.parse(data);

                if (result.Status === true) {

                    clearBundleTable();

                    displayBundleTable(result.Bundle);

                    attachRemoveClick();

                    getProducts(request.answer);

                    showBundleDiv();

                } else {
                    alert(result.Message);
                }

            })
            .catch(function (err) {
                alert(err);
            });
    };

    //public methods
    return {
        init: init,
        getBundle: getBundle
    };
}();


