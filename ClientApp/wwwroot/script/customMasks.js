window.masks = (element, type) => {

    if (element && type === "phone") {
        IMask(element, {
            mask: '(00) 0 0000-0000'
        });
    }

    if (element && type === "cnpj") {
        IMask(element, {
            mask: '00.000.000/0000-00'
        });
    }
};
