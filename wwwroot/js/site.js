// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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


});