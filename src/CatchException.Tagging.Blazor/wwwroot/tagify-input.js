
let tagify,
    controller;

export function initial(dotNetObjectRef, id) {
    const input = document.getElementById(id);
    tagify = new Tagify(input,
        {
            whitelist: [],
            maxTags: 5,
            dropdown: {
                maxItems: 20,           // <- mixumum allowed rendered suggestions
                classname: "tags-look", // <- custom classname for this dropdown, so it could be targeted
                enabled: 0,             // <- show suggestions on focus
                closeOnSelect: false    // <- do not hide the suggestions dropdown once an item has been selected
            }
        });
    tagify.on('input', onInput);
    getWhitelist('');

    input.addEventListener('change', onChange);

    function onChange(e) {
        console.log(e.target.tagifyValue);
        let tags = null;
        if (e.target.tagifyValue) {
            tags = JSON.parse(e.target.tagifyValue);
        }

        dotNetObjectRef.invokeMethodAsync('OnValueChangedAsync', tags);
    }

    function getWhitelist(keyword) {
        if (!tagify) {
            return;
        }

        tagify.whitelist = null;
        tagify.loading(true).dropdown.hide();
        dotNetObjectRef.invokeMethodAsync('GetWhitelistAsync', keyword)
            .then(data => {
                tagify.whitelist = data;
                tagify.loading(false).dropdown.show(keyword);
            });
    }
    function onInput(e) {
        let value = e.detail.value;
        getWhitelist(value);
    }

}
