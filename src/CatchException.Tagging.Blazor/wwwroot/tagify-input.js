
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
                //enabled: 0,             // <- show suggestions on focus
                closeOnSelect: false    // <- do not hide the suggestions dropdown once an item has been selected
            }
        });
    tagify.on('input', onInput);

    //input.addEventListener('change', onChange);

    //function onChange(e) {
    //    dotNetObjectRef.invokeMethodAsync('OnValueChangedAsync', JSON.parse(e.target.value));
    //}

    function onInput(e) {
        let value = e.detail.value;
        if (value.length < 2) {
            tagify.whitelist = null;
            tagify.loading(false).dropdown.hide();
            return;
        }
        if (!tagify) {
            return;
        }
        
        tagify.whitelist = null;
        tagify.loading(true).dropdown.hide();
        dotNetObjectRef.invokeMethodAsync('GetWhitelistAsync', value)
            .then(data => {
                console.log(data);
                tagify.whitelist = data;
                tagify.loading(false).dropdown.show(value);
            });
    }
}
