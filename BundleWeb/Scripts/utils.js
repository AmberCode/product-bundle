const utils = function () {

    const convertAge = (data) => {
        switch (data) {
            case "0-17":
                return 17;
            case "18-64":
                return 18;
            case "65+":
                return 65;
        }

        return data;
    };

    const convertIncome = (data) => {
        switch (data) {
            case "1-12000":
                return 1;
            case "12001-40000":
                return "12001";
            case "40001+":
                return "40001";
        }

        return data;
    };


    return {
        convertAge: convertAge,
        convertIncome: convertIncome
    };

}();