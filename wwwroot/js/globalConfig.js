// Global Configuration
$(document).ready(function () {
	$.support.cors = true;

	$('.DatePicker').datepicker({
		format: "mm/dd/yyyy",
		autoclose: true,
		//title: "Select BD",
		todayHighlight: true,
		//startView: 'decade',
		weekStart: 6
	});

	// extend range validator method to treat checkboxes differently
	$.validator.methods.range = function (value, element, param) {
		if (element.type === 'checkbox' && element.classList.contains("must-check")) {
			// if it's a checkbox return true if it is checked
			return element.checked;
		} else {
			// otherwise run the default validation function
			return $.validator.methods.range.call(this, value, element, param);
		}
	}
});