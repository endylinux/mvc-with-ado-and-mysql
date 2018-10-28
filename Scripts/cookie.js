function Cookie() {
	this.key = "";
	this.value = "";
	this.domain = "";
	this.path = "";
	this.expires = 0;
	this.date = new Date();

	this.setCookie = function () {
		this.date.setTime(this.date.getTime() + this.expires);
		document.cookie = this.key + "=" + this.value +
			";expires=" + this.date.toUTCString() +
			";domain=" + this.domain +
			";path=" + this.path;
	};

	this.isSet = function () {
		var key = this.key;
		var value = this.value;
		var cookies = document.cookie.split(';');

		var returnValue = false;
		$.each(cookies, function (k, v) {
			var trimmed = $.trim(v);
			var keyValue = trimmed.split('=');
			if (keyValue[0] === key && keyValue[1] === value) {
				returnValue = true;
			}
		});

		return returnValue;
	};
}