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