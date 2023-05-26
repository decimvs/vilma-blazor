
export function initEditor(configuration) {
    tinymce.init({
        selector: configuration.selector,
        base_url: configuration.base_url,
        suffix: configuration.suffix,
        promotion: configuration.promotion,
        skin: configuration.skin,
        plugins: ['image', 'link'],
        file_picker_callback: filePickerCallback
    });
}

function filePickerCallback(callback, value, meta) {
    console.log('File picker requested');
}