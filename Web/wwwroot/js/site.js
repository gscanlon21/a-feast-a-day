jQuery.fn.cleanWhitespace = function () {
    this.contents().filter(function () {
        return (this.nodeType == 3 && !/\S/.test(this.nodeValue));
    }).remove();

    return this;
}

// Alert dismissing for bootstrap. I'm not including their JS.
$("[data-dismiss]").each((i, elem) => elem.addEventListener('click', (e) => {
    const parent = $(elem).parent(elem.dataset.dismiss);
    const grandParent = parent.parent();
    parent.remove();
    grandParent.cleanWhitespace();
}));

// Searchable select boxes.
$('select.searchable').select2({ theme: 'bootstrap-5' });


window.tdb = function (dbName, dbVersion, storeName) {
    this.db;
    this.dbName = dbName;
    this.dbVersion = dbVersion;
    this.storeName = storeName;

    this.openDB = function (success = (() => { }), callback = (() => { })) {
        if (!window.indexedDB) {
            callback({ message: 'Unsupported indexedDB' });
        }

        let request = window.indexedDB.open(this.dbName, this.dbVersion);

        request.onsuccess = e => {
            this.db = request.result;
            success();
        };
        request.onerror = e => callback(e.target.error);
        request.onupgradeneeded = e => {
            this.db = e.target.result;
            this.db.onabort = e2 => callback(e2.target.error);
            this.db.error = e2 => callback(e2.target.error);

            if (!this.db.objectStoreNames.contains(storeName)) {
                this.db.createObjectStore(storeName);
            }
        };
    }

    this.deleteDB = function () {
        if (window.indexedDB) {
            window.indexedDB.deleteDatabase(this.dbName);
        }
    }

    this.deleteStore = function (storeName, callback = (() => { })) {
        if (this.db) {
            this.db.deleteObjectStore();
            this.db.oncomplete = e => callback(e.target.result);
            this.db.onabort = e => callback(e.target.error);
            this.db.error = e => callback(e.target.error);
        }
    }

    this.upsert = function (storeName, key, data, callback = (() => { })) {
        if (this.db && data) {
            let transaction = this.db.transaction([storeName], 'readwrite');
            transaction.onabort = te => callback(te.target.error);
            transaction.onerror = te => callback(te.target.error);

            let request = transaction.objectStore(storeName).put(data, key);
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.get = function (storeName, key, callback = (() => { })) {
        if (this.db && key) {
            let request = this.db.transaction([storeName]).objectStore(storeName).get(key)
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.getAll = function (storeName, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction(storeName).objectStore(storeName).openCursor(null, 'next');
            let results = [];
            request.onsuccess = e => {
                let cursor = e.target.result;
                if (cursor) {
                    console.log("Key:" + cursor.key + " Value:" + cursor.value);
                    results.push({ [cursor.key]: cursor.value });
                    cursor.continue();
                } else {
                    callback(results);
                }
            };
            request.onerror = e => callback(e.target.error);
        }
    }

    this.remove = function (storeName, key, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction([storeName], 'readwrite').objectStore(storeName).delete(key);
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.clear = function (storeName, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction([storeName], 'readwrite').objectStore(storeName).clear();
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.count = function (storeName, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction([storeName]).objectStore(storeName).count();
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    return this;
}