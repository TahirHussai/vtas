var dotNetObject;

export async function addEditorToElement(dotNetRef, options) {
    dotNetObject = dotNetRef;

    TXTextControl.init({
        containerID: "txDocumentEditorContainer",
        webSocketURL: options.websocketurl
    });

}

export function saveDocument() {

    // save the document on TXTextControl object
    TXTextControl.saveDocument(TXTextControl.StreamType.InternalUnicodeFormat, function (document) {
        // call the .NET method 'ProcessDocument' with the saved document data
        dotNetObject.invokeMethodAsync('ProcessDocument', document.data);
    });

};

export function loadDocument(document) {
    // load the document back into the editor (TXTextControl)
    TXTextControl.loadDocument(TXTextControl.StreamType.InternalUnicodeFormat, document);
};

export function insertTable() {
    TXTextControl.tables.add(5, 5, 10, function (e) {
        if (e === true) { // if added
            TXTextControl.tables.getItem(function (table) {
                table.cells.forEach(function (cell) {

                    cell.setText("Cell text");

                });
            }, null, 10);
        }
    })
};