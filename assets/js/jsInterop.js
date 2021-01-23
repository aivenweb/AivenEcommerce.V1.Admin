window.AivenEcommerceAdmin = {
    showModal: function (elementId) {
        var myModal = new bootstrap.Modal(document.getElementById(elementId),
            {
                backdrop: 'static',
                keyboard: false
            });

        myModal.show();
        feather.replace();

    },

    hideModal: function (elementId) {
        var myModal = new bootstrap.Modal(document.getElementById(elementId), {
            keyboard: false
        })

        myModal.hide();
    },
    createDropZone: function (selector, url) {
        var myDropzone = new Dropzone(selector, { url: url });

    },
    replaceIcons: function () {
        feather.replace();
    },
    createChoice: function (selector) {
        const element = document.querySelector(selector);
        const choices = new Choices(element,
            {
                addItems: true,
                addItemFilter: null,
                duplicateItemsAllowed: false,
                placeholder: true,
                loadingText: 'Cargando...',
                noResultsText: 'No se encuentra',
                noChoicesText: 'Vacio',
                itemSelectText: 'Selecciona',
                addItemText: (value) => {
                    return `Agregar <b>"${value}"</b>`;
                },
                valueComparer: (value1, value2) => {
                    return value1 === value2;
                },
            });


    },
    createChoiceVariantNameInput: function (selector, dotNetObjRef) {
        const element = document.querySelector(selector);

        element.addEventListener(
            'addItem',
            function (event) {
                dotNetObjRef.invokeMethodAsync("AddItem", event.detail.value);
            },
            false,
        );

        element.addEventListener(
            'removeItem',
            function (event) {
                dotNetObjRef.invokeMethodAsync("RemoveItem", event.detail.value);
            },
            false,
        );

        const choices = new Choices(element,
            {
                paste: false,
                duplicateItemsAllowed: false,
                editItems: true,
                addItems: true,
                addItemFilter: null,
                duplicateItemsAllowed: false,
                placeholder: true,
                loadingText: 'Cargando...',
                noResultsText: 'No se encuentra',
                noChoicesText: 'Vacio',
                itemSelectText: 'Selecciona',
                addItemText: (value) => {
                    return `Agregar <b>"${value}"</b>`;
                },
                valueComparer: (value1, value2) => {
                    return value1 === value2;
                },
            });


    },
    createChoiceVariantValueInput: function (selector, variantName, dotNetObjRef) {
        const element = document.querySelector(selector);

        element.addEventListener(
            'addItem',
            function (event) {
                dotNetObjRef.invokeMethodAsync("AddValueItem", variantName, event.detail.value);
            },
            false,
        );

        element.addEventListener(
            'removeItem',
            function (event) {
                dotNetObjRef.invokeMethodAsync("RemoveValueItem", variantName, event.detail.value);
            },
            false,
        );

        const choices = new Choices(element,
            {
                paste: false,
                duplicateItemsAllowed: false,
                editItems: true,
                addItems: true,
                addItemFilter: null,
                duplicateItemsAllowed: false,
                placeholder: true,
                loadingText: 'Cargando...',
                noResultsText: 'No se encuentra',
                noChoicesText: 'Vacio',
                itemSelectText: 'Selecciona',
                addItemText: (value) => {
                    return `Agregar <b>"${value}"</b>`;
                },
                valueComparer: (value1, value2) => {
                    return value1 === value2;
                },
            });


    },
    createChoiceCouponCodeCustomerInput: function (selector, dotNetObjRef) {
        this.createChoiceCouponCodeCategoryInput(selector, dotNetObjRef);
    },
    createChoiceCouponCodeProductInput: function (selector, dotNetObjRef) {
        this.createChoiceCouponCodeCategoryInput(selector, dotNetObjRef);
    },
    createChoiceCouponCodeSubCategoryInput: function (selector, dotNetObjRef) {
        this.createChoiceCouponCodeCategoryInput(selector, dotNetObjRef);
    },
    createChoiceCouponCodeCategoryInput: function (selector, dotNetObjRef) {
        const element = document.querySelector(selector);

        element.addEventListener(
            'addItem',
            function (event) {
                dotNetObjRef.invokeMethodAsync("AddItem", event.detail.value);
            },
            false,
        );

        element.addEventListener(
            'removeItem',
            function (event) {
                dotNetObjRef.invokeMethodAsync("RemoveItem", event.detail.value);
            },
            false,
        );

        const choices = new Choices(element,
            {
                paste: false,
                duplicateItemsAllowed: false,
                editItems: true,
                duplicateItemsAllowed: false,
                placeholder: true,
                loadingText: 'Cargando...',
                noResultsText: 'No se encuentra',
                noChoicesText: 'Vacio',
                itemSelectText: 'Selecciona',
                addItemText: (value) => {
                    return `Agregar <b>"${value}"</b>`;
                },
                valueComparer: (value1, value2) => {
                    return value1 === value2;
                },
            });


    },
    getValueChoice: function (selector) {
        const choices = new Choices(selector);
        return choices.getValue(true);
    },
    setValueChoice: function (selector, items) {
        const choices = new Choices(selector);
        return choices.setValue(items);
    },

    clearChoice: function (selector) {
        const choices = new Choices(selector);
        choices.clearStore();
    },
    quillEditor: {},
    createEditor: function (selector) {
        var self = this;
        self.quillEditor = new Quill(selector, {
            bounds: "#full-container .editor",
            modules: {
                toolbar: [
                    [{ font: [] }, { size: [] }],
                    ["bold", "italic", "underline", "strike"],
                    [
                        { color: [] },
                        { background: [] }
                    ],
                    [
                        { script: "super" },
                        { script: "sub" }
                    ],
                    [
                        { list: "ordered" },
                        { list: "bullet" },
                        { indent: "-1" },
                        { indent: "+1" }
                    ],
                    ["direction", { align: [] }],
                    ["link", "image", "video"],
                    ["clean"]]
            },
            theme: "snow"
        })
    },
    getEditorHtml: function () {
        return this.quillEditor.root.innerHTML;
    }
}


window.onSignIn = function (googleUser) {
    console.log(googleUser.uc.id_token);

    DotNet.invokeMethodAsync('AivenEcommerce.V1.Admin.Wasm', 'ReturnArrayAsync', googleUser.uc.id_token)
        .then(data => {
            data.push(4);
            console.log(data);
        });
}

window.signOut = function () {
    var auth2 = gapi.auth2.getAuthInstance();
    auth2.signOut().then(function () {
        console.log('User signed out.');
    });
}

window.loadJS = function (url) {
    //url is URL of external file, implementationCode is the code
    //to be called from the file, location is the location to 
    //insert the <script> element

    var scriptTag = document.createElement('script');
    scriptTag.src = url;

    document.body.appendChild(scriptTag);
};
