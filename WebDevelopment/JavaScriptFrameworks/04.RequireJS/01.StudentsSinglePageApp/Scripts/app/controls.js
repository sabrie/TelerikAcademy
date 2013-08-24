﻿/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
define(["libs/class"], function (Class) {
	var controls = controls || {};
	var ListView = Class.create({
		init: function (itemsSource) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ListView must be an array!";
			}
			this.itemsSource = itemsSource;
		},
		render: function (template) {
		    var list = document.createElement("ul");
		    list.setAttribute("class", "students-list");
			for (var i = 0; i < this.itemsSource.length; i++) {
			    var listItem = document.createElement("li");
			    listItem.setAttribute("id", this.itemsSource[i].id);
			    list.setAttribute("class", "student");
				var item = this.itemsSource[i];
				listItem.innerHTML = template(item);
				list.appendChild(listItem);
			}
			return list.outerHTML;
		},

	//    renderMarks: function (template, id) {
	//        var list = document.createElement("ul");
	//        list.setAttribute("class", "marks-list");

	//        // student with given id
	//        var item = this.itemsSource[id];

	//        var listItem = document.createElement("li");	        
	//        listItem.innerHTML = template(item);
	//        list.appendChild(listItem);

	//        return list.outerHTML;
	//}
	});
	controls.listView = function (itemsSource) {
		return new ListView(itemsSource);
	}

	return controls;
});