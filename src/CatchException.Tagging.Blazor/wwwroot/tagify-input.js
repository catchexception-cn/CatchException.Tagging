
let tagify,
    controller;

export function initial(dotNetObjectRef, id) {
    const input = document.getElementById(id);
    tagify = new Tagify(input, { whitelist: [] });

    input.addEventListener('change', onChange);

    function onChange(e) {
        dotNetObjectRef.invokeMethodAsync('OnValueChangedAsync', JSON.parse(e.target.value));
    }

    function onInput(e) {
        let inputValue = e.detail.value;
        if (inputValue.length < 2) {
            return;
        }
        if (!tagify) {
            return;
        }

        tagify.whitelist = null;
        tagify.loading(true).dropdown.hide();

        dotNetObjectRef.invokeMethodAsync('GetWhitelistAsync', inputValue)
            .then(data => {
                console.log(data);
                tagify.whitelist = data;
            });
    }
}
