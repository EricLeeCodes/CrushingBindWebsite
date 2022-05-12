(function () {
    window.QuillFunctions = {
        createQuill: function (quillElement, hasToolbar) {
            var options = {
                debug: 'info',
                modules: {
                    toolbar: hasToolbar ? toolbarOptions : false
                },
                placeholder: 'This post has no content',
                readOnly: false,
                theme: 'snow',
                bounds: quillElement
            };

            new Quill(quillElement, options);

        },

        getQuillContent: function (quillControl) {
            return JSON.stringify(quillControl.__quill.getContents());
        },
        setQuillContent: function (quillControl, quillContent) {
            content = JSON.parse(quillContent);
            return quillControl.__quill.setContents(content, 'api');
        },


        disableQuillEditor: function (quillControl) {
            quillControl.__quill.enable(false);
        }
    };
})();


var toolbarOptions = [
    // toggled buttons
    ['bold', 'italic', 'underline', 'strike'],
    ['blockquote', 'code-block'],

    // custom button values
    [{ 'header': 1 }, { 'header': 2 }],               
    [{ 'list': 'ordered' }, { 'list': 'bullet' }],

    // superscript and subscript
    [{ 'script': 'sub' }, { 'script': 'super' }],

    // outdent and indent
    [{ 'indent': '-1' }, { 'indent': '+1' }],

    // text direction
    [{ 'direction': 'rtl' }],                         

    // custom dropdown
    [{ 'size': ['small', false, 'large', 'huge'] }],
    [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

    // dropdown with defaults from theme
    [{ 'color': [] }, { 'background': [] }],          
    [{ 'font': [] }],
    [{ 'align': [] }],

    // links and images
    ['link', 'image']

    // remove formatting button
    ['clean']                                         
];
