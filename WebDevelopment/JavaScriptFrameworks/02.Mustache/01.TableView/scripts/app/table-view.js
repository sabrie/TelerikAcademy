/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />

var controls = controls || {};
(function (c) {
    var TableView = Class.create({
        init: function (itemsSource, rows, cols) {
            if (!(itemsSource instanceof Array)) {
                throw "The itemsSource of a TableView must be an array!";
            }
            this.itemsSource = itemsSource;
            this.rows = rows;
            this.cols = cols;
        },
        render: function (template) {
            var table = document.createElement("table");
            var index = 0;

            for (var j = 0; j < this.rows; j++) {

                if (index == this.itemsSource.length) {
                    break;
                }

                var tr = document.createElement("tr");

                for (var i = 0; i < this.cols; i++) {
                    var td = document.createElement("td");
                    var item = this.itemsSource[index];
                    td.innerHTML = template(item);
                    tr.appendChild(td);
                    table.appendChild(tr);
                    index++;
                }               
            }            

            return table.outerHTML;
        }
    });

    c.getTableView = function (itemsSource, rows, cols) {
        return new TableView(itemsSource, rows, cols);
    }
}(controls || {}));


