function setDivHeight (section) {
	var maxHeight = 0;

	$(section).each(function(index){
	if ($(this).height() > maxHeight)
	{
	maxHeight = $(this).height();
	}
	});

	$(section).height(maxHeight);
}

setDivHeight ('.home-quicklink .item-wrapper')

/* Display Copyright Year */
var d = new Date();
var n = d.getFullYear();
document.getElementById("year").innerHTML = n;

