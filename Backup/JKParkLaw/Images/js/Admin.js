function extractNumber(obj, decimalPlaces, allowNegative)
{
	var temp = obj.value;

	// avoid changing things if already formatted correctly
	var reg0Str = '[0-9]*';
	if (decimalPlaces > 0) {
		reg0Str += '\\.?[0-9]{0,' + decimalPlaces + '}';
	} else if (decimalPlaces < 0) {
		reg0Str += '\\.?[0-9]*';
	}
	reg0Str = allowNegative ? '^-?' + reg0Str : '^' + reg0Str;
	reg0Str = reg0Str + '$';
	var reg0 = new RegExp(reg0Str);
	if (reg0.test(temp)) return true;

	// first replace all non numbers
	var reg1Str = '[^0-9' + (decimalPlaces != 0 ? '.' : '') + (allowNegative ? '-' : '') + ']';
	var reg1 = new RegExp(reg1Str, 'g');
	temp = temp.replace(reg1, '');

	if (allowNegative) {
		// replace extra negative
		var hasNegative = temp.length > 0 && temp.charAt(0) == '-';
		var reg2 = /-/g;
		temp = temp.replace(reg2, '');
		if (hasNegative) temp = '-' + temp;
	}

	if (decimalPlaces != 0) {
		var reg3 = /\./g;
		var reg3Array = reg3.exec(temp);
		if (reg3Array != null) {
			// keep only first occurrence of .
			//  and the number of places specified by decimalPlaces or the entire string if decimalPlaces < 0
			var reg3Right = temp.substring(reg3Array.index + reg3Array[0].length);
			reg3Right = reg3Right.replace(reg3, '');
			reg3Right = decimalPlaces > 0 ? reg3Right.substring(0, decimalPlaces) : reg3Right;
			temp = temp.substring(0,reg3Array.index) + '.' + reg3Right;
		}
	}

	obj.value = temp;
}
function blockNonNumbers(obj, e, allowDecimal, allowNegative)
{
	var key;
	var isCtrl = false;
	var keychar;
	var reg;

	if(window.event) {
		key = e.keyCode;
		isCtrl = window.event.ctrlKey
	}
	else if(e.which) {
		key = e.which;
		isCtrl = e.ctrlKey;
	}

	if (isNaN(key)) return true;

	keychar = String.fromCharCode(key);

	// check for backspace or delete, or if Ctrl was pressed
	if (key == 8 || isCtrl)
	{
		return true;
	}

	reg = /\d/;
	var isFirstN = allowNegative ? keychar == '-' && obj.value.indexOf('-') == -1 : false;
	var isFirstD = allowDecimal ? keychar == '.' && obj.value.indexOf('.') == -1 : false;

	return isFirstN || isFirstD || reg.test(keychar);
}

function cleanURL(URLString)
{
	URLString = URLString.strip();
	var rgx = new RegExp('[^0-9A-Za-z]','g');
	URLString = URLString.replace(rgx,'-');
	var rgx = new RegExp('[-]+','g');
	URLString = URLString.replace(rgx,'-');
	return URLString;
}
function makeUrlFromTo(fromInput,toInput)
{
	var fromValue = $(fromInput).value;
	fromValue = fromValue.toLowerCase()
	$(toInput).value = cleanURL(fromValue);
}
function isURLOK(url){
    if (url.length >= 3) return true;
    else return false;
}
function AddValueToInput(str,inp)
{
    $(inp).value+= " " + str;
}
function AddVariableToInput(str,inp)
{
    $(inp).value+= " [" + str +"]";
}

function toogleEnabled(ckb,item)
{

    if ($(ckb).checked == true)
    {
        $(item).disabled = false;
    }
    else
    {
        $(item).disabled = true;
        $(item).value = '';
    }
}

function ToogleVisibility(targetName)
{
    var target = $(targetName);
    var cookieName = targetName + "_visible";
    var status;
    if (target != null)
    {
        
        status = readCookie(cookieName);
        if (status == "true") 
        {
            eraseCookie(cookieName);
            target.style.display = '';
        }
        else
        {
            createCookie(cookieName,"true")
            target.style.display = 'none';
        }
    }
}
function CheckVisibility(targetName)
{
    var target = $(targetName);
    var cookieName = targetName + "_visible";
    var status;
    if (target != null)
    {
        
        status = readCookie(cookieName);
        if (status == "true") 
        {
            target.style.display = 'none';
        }
        else
        {
            target.style.display = '';
        }
    }
}
function createCookie(name,value,days) {
	if (days) {
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "; expires="+date.toGMTString();
	}
	else var expires = "";
	document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) {
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
}

function eraseCookie(name) {
	createCookie(name,"",-1);
}
function SetValueURL(containerID,newValue,checkBtn,imgSrc,statusdiv)
{
    var container = $(containerID);
    var checker = $(checkBtn);
    var status = $(statusdiv);
    container.value = newValue;
    checker.src = imgSrc;
    status.innerHTML = "Check URL";
}



	