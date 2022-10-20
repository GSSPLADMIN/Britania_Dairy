/*************************************************************************************/
var imgChecked = new Image();
imgChecked.src = "../images/check_box_tick.gif";
var imgUnChecked = new Image();
imgUnChecked.src = "../images/check_box.gif";
var strDateSeparator = "/";


/********************************************************************************
function - DisableLink

linkName - id of anchor to be disabled
disable - boolean - pass true to disable anchor; false otherwise

Assumptions:
To use this function, you must set your forms as follows
(1) You must have a div tag that represents disabled anchor with the following ID pattern - "div"+anchorID.substring(3, anchorID.length) +"Dis"
(2) The function assumes that anchors exist in parent.frames.content.document

*********************************************************************************/


function DisableLink(anchorID, disable) {
    var objAnchor = parent.frames.content.document.getElementById(anchorID);
    var objDisabledDiv = parent.frames.content.document.getElementById("div" + anchorID.substring(3, anchorID.length) + "Dis");

    if (objAnchor == 'undefined' || objAnchor == null)
        return;

    if (disable) {
        objAnchor.style.display = "none";
        objDisabledDiv.style.display = "";
    }
    else {
        objAnchor.style.display = "";
        objDisabledDiv.style.display = "none";
    }
}





/***************************
ValidateBlank(ctrl)
ctrl - control to be validated
returns true if control has some value, false otherwise

******************************/
function ValidateBlank(ctrl) {
    if (Trim(ctrl.value).length == 0)
        return false;
    else
        return true;
}

/********************
EnableLink() - this function enables/disables an HTML anchor element
linkControl - the HTML anchor element to be enabled/disabled
enable - if true, the element will be enabled
enableCSSClass = class to be applied when link is enabled; set cursor:hand in this class
disableCSSClass = class to be applied when link is disabled; set cursor;default in this class

The function can be extended to include HREF attribute
**********************/
var arrOnClickJS = new Array();
var arrOnMouseoverJS = new Array();
var arrOnMouseoutJS = new Array();
function EnableLink(linkControl, enable, enableCSSClass, disableCSSClass) {

    if (arrOnClickJS[linkControl.id] == null) {
        //alert(linkControl.onclick);
        arrOnClickJS[linkControl.id] = linkControl.onclick;//store temporarily before deleting
        //alert(arrOnClickJS[linkControl.id]);
        arrOnMouseoverJS[linkControl.id] = linkControl.onmouseover;//store temporarily before deleting
        arrOnMouseoutJS[linkControl.id] = linkControl.onmouseout;//store temporarily before deleting
    }

    if (enable) {
        linkControl.onclick = eval(arrOnClickJS[linkControl.id]);//works well in both IE and Mozilla
        linkControl.onmouseover = eval(arrOnMouseoverJS[linkControl.id]);//works well in both IE and Mozilla
        linkControl.onmouseout = eval(arrOnMouseoutJS[linkControl.id]);//works well in both IE and Mozilla
        linkControl.className = enableCSSClass;
    }
    else {
        linkControl.onclick = "";//works well in both IE and Mozilla
        linkControl.onmouseover = "";
        linkControl.onmouseout = "";
        linkControl.className = disableCSSClass;
    }

}

/*********************************************************************************
SingleSelect(clickedImage)

The function allws only single selection of an item at client side.  It works with the image checkboxes (images used along with checkboxes)
The function relates images and checkboxes on the basis of their client side id
For example, to find corresponding checkbox for image 'imgchk56', the function will look for checkbox with id '56'

To reuse this function, the following must be done:
(1)Call this function on click event of image - SingleSelect(this)
(2)Give id to image checkbox in this pattern - 'imgchk' + <id of corresponding checkbox>

*********************************************************************************/
function SingleSelect(sender) {
    var frm = document.forms[0];

    for (i = 0; i <= frm.elements.length - 1; i++) {
        var ctrl = frm.elements[i];
        if (ctrl.type == "checkbox") {
            var len = sender.id.length;
            if (ctrl.id != sender.id.substring(6, len))//excepting the checkbox which was clicked, uncheck all other checkboxes
                ctrl.checked = false;
        }

    }

    for (i = 0; i <= document.images.length - 1; i++) {
        var ctrl = document.images[i];
        if (ctrl.id != sender.id && ctrl.id.substring(0, 6) == "imgchk")//excepting the image which was clicked, uncheck all other checkbox images
            ctrl.src = imgUnChecked.src;
    }

}

/***********************************************
GetStringFromDate(dtDate)
returns string representation of date object - format - hh/mm/yy hh:mm


***********************************************/
function GetStringFromDate(dtDate) {
    if (dtDate == null || dtDate == 'undefined' || dtDate == '')
        return "";

    var day = (dtDate.getDate()).toString().length == 2 ? dtDate.getDate() : '0' + dtDate.getDate();
    if (isNaN(day))
        return ""; //return false;

    var month = (dtDate.getMonth() + 1).toString().length == 2 ? (dtDate.getMonth() + 1) : '0' + (dtDate.getMonth() + 1);
    if (isNaN(month))
        return ""; //return false;

    var year = dtDate.getFullYear().toString().substring(2, 4);  //date format change; change 2 to No digits of the year to display. currently showing 'yy'			
    if (isNaN(year))
        return ""; //return false;

    var hours = dtDate.getHours().toString();
    if (isNaN(hours))
        return "";

    var minutes = dtDate.getMinutes().toString();
    if (isNaN(minutes))
        return "";

    val = day + strDateSeparator + month + strDateSeparator + year + " " + hours + ":" + minutes;

    return val;
}

/************************************
returns date object from string - format dd/mm/yy hh:mm
*************************************/
function GetDateFromString(strDate) {
    if (strDate == null || strDate == 'undefined')
        return null;

    var day = strDate.substring(0, 2);//dd
    var month = strDate.substring(3, 5) - 1;//mm
    var year = strDate.substring(6, 8);//yy
    if ((year * 1) > 70)//if year > 70, we consider it to be before 2000
        year = "19" + year;
    else
        year = "20" + year;
    var hour = strDate.substring(9, 11);//hh
    var minute = strDate.substring(12);//mm
    var dtpDate = new Date(year, month, day, hour, minute);

    return dtpDate;
}

/*****************************************************************
Validates that the given date is not a past date - date format - dd/mm/yy hh:mm
*****************************************************************/
function ValidatePastDate(dateString) {
    var dtToday = new Date();
    return GeneralCompare(dateString, "GreaterEqual", GetStringFromDate(dtToday), "date");
}


/*****************************************************************************
Date Validation function
 
Checks if the date string is valid and returns null if not valid.
If valid, converts it to the appropriate date object, and returns it 
******************************************************************************/

function ValidateDate(dateString) {
    var dateMatchExp = new RegExp("^(\\d{1,2})/(\\d{1,2})/(\\d{4})$");
    var match = dateMatchExp.exec(dateString);
    if (null == match) return null;	//Match failed, invalid date

    if (match[1] < 1 || match[1] > 12) return null;	//validate month
    if (match[2] < 1 || match[2] > 31) return null;	//validate day
    if (match[3] < 1) return null;	//validate year

    // valid day check
    if (match[1] == 2) 		// february check
    {
        if (match[2] > 29) return null;
        //Check for leap year.
        if (((match[3] % 100 == 0 || match[3] % 4 != 0) && (match[3] % 400 != 0))  // non-leap year checked
				&& match[2] > 28) return null;
    }
    else if ((match[1] == 4 || match[1] == 6 || match[1] == 9 || match[1] == 11) && (match[2] > 30))
        return null;

    return new Date(match[3], match[1] - 1, match[2]);
}


/******************************************************************************************************
 * This function validates the date in any format
 * @author Ishan
 * @param datestr String representing the Date to be checked
 * @param delim String representing the delimiter that separates, date, month and year
 * date string
 * @param dd Integer value (0 to 2) indicating the position of the date field in the date String
 * @param mm Integer value (0 to 2) indicating the position of the month field in the date String
 * @param yy Integer value (0 to 2) indicating the position of the year field in the date String
 * @return Returns the boolean value true if the date is valid, false otherwise
 *******************************************************************************************************/
function dateCheck(datestr, delim, dd, mm, yy) {
    if (dd < 0 || dd > 2 || mm < 0 || mm > 2 || yy < 0 || yy > 2 || dd == mm || mm == yy || dd == yy) return false;
    datestr = datestr.trim();
    delim = delim.trim();
    if (datestr.length <= 0 || delim.length <= 0) return false;
    var dt = datestr.split(delim);
    if (dt.length != 3) return false;
    if (isNaN(dt[dd]) || isNaN(dt[mm]) || isNaN(dt[yy])) return false;
    if (Math.floor(dt[dd]) != Math.ceil(dt[dd]) || Math.floor(dt[mm]) != Math.ceil(dt[mm]) || Math.floor(dt[yy]) != Math.ceil(dt[yy])) return false;
    if (dt[mm] < 1 || dt[mm] > 12 || dt[dd] < 1 || dt[dd] > 31 || dt[yy] < 1) return false;

    if (dt[mm] == 2) {

        if (dt[dd] > 29) return false;
        //	Check for leap year.
        if (dt[yy] % 100 == 0 && dt[yy] % 400 != 0 && dt[dd] > 28) return false;
        if (dt[yy] % 4 != 0 && dt[dd] > 28) return false;
    }

    if ((dt[mm] == 4 || dt[mm] == 6 || dt[mm] == 9 || dt[mm] == 11) && dt[dd] > 30) return false;
    return true;
}

/**
 * This function validates the date in dd/mm/yyyy format
 * @author Ishan
 * @param datestr String representing the Date to be checked
 * @return Returns the boolean value true if the date is valid, false otherwise
 */
function dateCheckMain(datestr) {
    return dateCheck(datestr, strDateSeparator, 2, 1, 0);
}

/*******************************************************************************
GeneralCompare - compares between all kinds of datatypes and operators

value1 - first value
operator - greater/lessthan/greaterequal etc
value2 - second value
type - datatype like number/date/string etc

*******************************************************************************/
function GeneralCompare(value1, operator, value2, type) {
    if (operator == "GreaterEqual" && type == "number")
        return (value1 >= value2);
    if (operator == "Greater" && type == "number")
        return (value1 > value2);
    if (operator == "GreaterEqual" && type == "date")//expects dates to be in string dd/mm/yy hh:mm format
        return (GetDateFromString(value1) >= GetDateFromString(value2));
}


/************************************************************
Validation functions for numeric an numeric fraction keypress 
************************************************************/
function NumericKeyPressFraction(passedEvent) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return;
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode == 46) || (keyCode == 13))
        return true;
    else
        return false;
}

function NumericKeyPress(passedEvent) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return;
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode == 13))
        return true;
    else
        return false;
}

function NumericKeyPressAllowNegative(passedEvent) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return;
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode == 13) || (keyCode == 45))
        return true;
    else
        return false;
}



/***************************************************************
Limits the length of text area HTML object
Use this function on onkeypress event of text area object
***************************************************************/
function LimitLength(passedEvent, maxLength) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return;
    if (navigator.appName == "Netscape")//mozilla compatibility
        return (passedEvent.target.value.length < maxLength)
    else
        return (passedEvent.srcElement.value.length < maxLength)
}


/*************************************************
Validates that only alpha-numeric characters are entered
**************************************************/
function AlphaNumericKeypress(passedEvent) {
    //only alpha-numeric characters are allowed - first character must not be a number

    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return;
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (keyCode == 13))
        return true;
    else
        return false;

}


/*************************************************
Validates that no textbox no the given form is blank
**************************************************/
function ValidateTextboxes() {
    var frm = document.forms[0];

    for (i = 0; i < frm.elements.length; i++)
        if (frm.elements[i].type == "text")
            if (Trim(frm.elements[i].value) == "")//some textbox is blank
                return false;

    return true;//if we reach here, it means no textbox is blank
}

/*************************************************
Changes location of parent
**************************************************/
function ChangeParentLocation(url) {
    window.parent.location = url;
}

/**********************************************************
* The function changes source of images of a given list of images
Used to set uncheck images to other images when an image has checked image

Before using this function, you must have a function in your caller page which returns CSV of control IDs that you want to loop through
for toggling the image.  The function name must be GetCSVControlID(). This has been done to improve performance.  This function (UncheckAllImagesExceptThis)
will generally be called on click event of items in a grid.  So, it will not be optimum to render such function with a huge list of CSV in the
click event of each item in grid.  Instead caller page should render GetCSVControlID() on page just once and then let UncheckAllImagesExceptThis
call GetCSVControlID() for getting the CSV.
**********************************************************/
function UncheckAllImagesExceptThis(checkedImageID) {
    var csvAllImageIDs = GetCSVControlID();
    if (csvAllImageIDs.length == 0)
        return;
    var arrControls = csvAllImageIDs.split(',');
    for (i = 0; i <= arrControls.length - 1; i++)
        if (arrControls[i] != checkedImageID)
            document.getElementById(arrControls[i]).src = imgUnChecked.src;
}


/**********************************************************
* The function changes source of images of a given list of images
Used to set uncheck images to other images when an image has checked image

Before using this function, you must have a function in your caller page which returns CSV of control IDs that you want to loop through
for toggling the image.  The function name must be GetCSVCheckedBoxesID(). This has been done to improve performance.  This function (UncheckAllCheckboxesExceptThis)
will generally be called on click event of items in a grid.  So, it will not be optimum to render such function with a huge list of CSV in the
click event of each item in grid.  Instead caller page should render GetCSVCheckedBoxesID() on page just once and then let UncheckAllCheckboxesExceptThis
call GetCSVCheckedBoxesID() for getting the CSV.
**********************************************************/
function UncheckAllCheckboxesExceptThis(checkedOneID) {
    var csvAllCheckboxes = GetCSVCheckedBoxesID();
    if (csvAllCheckboxes.length == 0)
        return;
    var arrControls = csvAllCheckboxes.split(',');
    for (i = 0; i <= arrControls.length - 1; i++)
        if (arrControls[i] != checkedOneID)
            document.getElementById(arrControls[i]).checked = false;
}



/**********************************************************
* This function is used for Toggling checkbox images
**********************************************************/
function ChangeImageSrcSpecial(objInput, strCheckBoxName) {
    try {

        if (objInput.src.toLowerCase() != imgChecked.src.toLowerCase()) {
            objInput.src = imgChecked.src;
            if (typeof (strCheckBoxName) != 'undefined' && strCheckBoxName != null)
                SetCheckStatusSpecial(true, strCheckBoxName);
        } else {
            objInput.src = imgUnChecked.src;
            if (typeof (strCheckBoxName) != 'undefined' && strCheckBoxName != null)
                SetCheckStatusSpecial(false, strCheckBoxName);
        }
    } catch (Exc) {
        alert('Error in ChangeImage.\r\n' + Exc.message);
    }
}
/**********************************************************
* This function is used for checking or unchecking checkbox
**********************************************************/
function SetCheckStatusSpecial(blnStatus, strCheckBoxName) {
    try {
        var objCheckBox = document.getElementById(strCheckBoxName);
        if (typeof (objCheckBox) != 'undefined' && objCheckBox != null) {
            objCheckBox.checked = blnStatus;
        } else {
            //alert('Unable to set check box status');
        }
    } catch (Exc) {
        //alert('Error in SetCheckStatus.\r\n' + Exc.message);
    }
}

/**********************************************************
* This function is used for Toggling checkbox images
 **********************************************************/
function ChangeImageSrc(objInput, strCheckBoxName) {
    try {

        if (objInput.src.toLowerCase() != imgChecked.src.toLowerCase()) {
            objInput.src = imgChecked.src;
            SetCheckStatus(true, strCheckBoxName);
        } else {
            objInput.src = imgUnChecked.src;
            SetCheckStatus(false, strCheckBoxName);
        }
    } catch (Exc) {
        //alert('Error in ChangeImage.\r\n' + Exc.message);
    }
}


/**********************************************************
* This function is used for Toggling checkbox images overload 1
 **********************************************************/
function ChangeImageSrc2(objImage, objCheckbox) {

    try {
        //first check the state of image and then toggle it
        if (objImage.src.toLowerCase() != imgChecked.src.toLowerCase()) {
            objImage.src = imgChecked.src;
            objCheckbox.checked = true;
        }
        else {
            objImage.src = imgUnChecked.src;
            objCheckbox.checked = false;
        }
    }
    catch (Exc) {
        //alert('Error in ChangeImage.\r\n' + Exc.message);
    }
}

/**********************************************************
* This function is used for checking or unchecking checkbox
 **********************************************************/
function SetCheckStatus(blnStatus, strCheckBoxName) {
    try {
        var objCheckBox = document.getElementById(strCheckBoxName);
        if (typeof (objCheckBox) != 'undefined' && objCheckBox != null) {
            objCheckBox.checked = blnStatus;
            objCheckBox.onclick();
        } else {
            //alert('Unable to set check box status');
        }
    } catch (Exc) {
        //alert('Error in SetCheckStatus.\r\n' + Exc.message);
    }
}
function ChangeImage(objInput) {
    var strName = objInput.id;
    objInput.src = "../images/check_box_tick.gif";
    //alert(strName);
}
/**********************************************************
* This function is used for opening new window
 **********************************************************/
function showPopupWindow(pageName, pageTitle, winHeight, winWidth) {
    var winTopPos = eval(screen.height - winHeight) / 2;
    var winLeftPos = eval(screen.width - winWidth) / 2;

    window.open(pageName, "", "top=" + winTopPos + ",left=" + winLeftPos + ",height=" + winHeight + ",width=" + winWidth + ",toolbar=none,scrollbars=1");
}
function showPopupWindowPDF(pageName, pageTitle, winHeight, winWidth) {
    var winTopPos = 3;
    var winLeftPos = eval(screen.width - winWidth) / 2;

    window.open(pageName, "", "top=" + winTopPos + ",left=" + winLeftPos + ",height=" + winHeight + ",width=" + winWidth + ",toolbar=none,scrollbars=1,resizable=yes,fullscreen");
}

/**********************************************************
 * This function is used for opening new window
 **********************************************************/
function openPopWin(winURL, winWidth, winHeight, moveX, moveY, winFeatures, winName) {
    var winDefaultFeatures;
    var popWin;
    if (openPopWin.arguments.length != 7)
        winName = "popUnder" + winCount++ //unique name for each pop-up window
    //winName = "popUnder"
    try {
        if (moveX == '' || moveY == '' && (isNan(winWidth) && isNaN(winHeight))) {
            moveX = (screen.width - winWidth) / 2;
            moveY = (screen.height - winHeight) / 2;
        }
    } catch (exc) {
        moveX = 0;
        moveY = 0;
    }
    winDefaultFeatures = "width=" + winWidth + ",height=" + winHeight + ",Top=" + moveY + ",Left=" + moveX + ",dependent=1,alwaysRasised=1";
    if (openPopWin.arguments.length == 6) //any additional features? 
        winFeatures = winDefaultFeatures + "," + winFeatures;
    else
        winFeatures = winDefaultFeatures;
    // open the new browser window
    popWin = window.open(winURL, winName, winFeatures, true)
    popWin.focus();
    return (popWin);
}
/****************************************************************************************
 * This function is used trimming the input string.
 ****************************************************************************************/

function Trim(strInput) {
    var ltrim = /^\s+/;
    var rtrim = /\s+$/;
    strInput = strInput.replace(ltrim, '');
    strInput = strInput.replace(rtrim, '');
    return strInput;
}

/****************************************************************************************
 * This function is used to enforce that atleast one checkbox should be checked in grid
 * when none of the checkboxes are selected in grid, it will return false
 ****************************************************************************************/
function validateGridSelection(oSource, oArgs) {
    //var checkedFlag = false;
    oArgs.IsValid = false;
    var argValid = false;
    var frm = document.forms[0];

    for (i = 0; i < frm.elements.length; i++) {
        if (frm.elements[i].type == "checkbox") {
            if (frm.elements[i].checked == true) {
                //checkedFlag = true;
                //break;
                oArgs.IsValid = true;
                argValid = true;
                break;
            }
        }
    }
    return argValid;
    /*	if(!checkedFlag)
        {
            alert('Please select atleast one checkbox');
        }*/
}

/*********************************************************************************
Validates that atleast one checkbox is selected on the given form

*********************************************************************************/
function ValidateSelectionInForm(targetForm) {
    var frm = targetForm;

    for (i = 0; i < frm.elements.length; i++)
        if (frm.elements[i].type == "checkbox")
            if (frm.elements[i].checked)
                return true;

    return false;

}

/*********************************************************************************
Validates that atleast one item is there in the given grid table and the grid is not blank
*********************************************************************************/
function ValidateRecordsInGrid(targetGridTable) {
    if (targetGridTable.rows.length > 1)//first row in data grid is header
        return true;
    else
        return false;

}



/*********************************************************************************
* Function Name	: setStatusScript
* Parameters		: strStatusbarHeading - Left Heading of Status Bar
                     strNoOfPages - No of links to be displayed (Excluding sublinks)
                     strCurrentPage - Current Page No
                     strPageHeading - Right Heading of Status Bar
                     blnIsFrame - true: frame; false: no frame
                     strNoOfSubPages - No of sublinks to be displayed
* Description		: Used to set status bar values
* Revision History	: Initial Revision by Paras Shah on 20/jul/2004
                     Modified by Parthiv for adding strNoOfSubPages on 
*********************************************************************************/
function setStatusScript(strStatusbarHeading, strNoOfPages, strCurrentPage, strPageHeading, blnIsFrame, strNoOfSubPages) {
    try {
        if (blnIsFrame == 'true')
            parent.parent.setStatusData(strStatusbarHeading, strNoOfPages, strCurrentPage, strPageHeading, blnIsFrame, strNoOfSubPages);
        else if (blnIsFrame == 'FrameParent')
            parent.parent.parent.setStatusData(strStatusbarHeading, strNoOfPages, strCurrentPage, strPageHeading, blnIsFrame, strNoOfSubPages);
        else
            parent.setStatusData(strStatusbarHeading, strNoOfPages, strCurrentPage, strPageHeading, blnIsFrame);
    } catch (Exc) {
        //Do Nothing
    }
}
/**********************************************************
 * This function is used to replace contents from the existing string.
 **********************************************************/
function Replace(strValue, strFind, strReplace) {
    if (trim(strValue) == "") return strValue;
    if (strValue.indexOf(strFind) == -1) return strValue;
    var reg = new RegExp(strFind, "g");//g stands for Global replcement.i can be used for ignoring case.
    var strReturn;
    try {
        strReturn = strValue;
        strReturn = strReturn.replace(reg, strReplace);
    } catch (exc) {
        strReturn = strValue;
        alert("Unable to replace string '" + strFind + "' with '" + strReplace + "' in\n" + strValue + "\n\nError Information: " + exc.name + " \nError Details: " + exc.message);
    }
    return strReturn;
}


/**********************************************************
 * This function is used to replace contents from the existing string.
 **********************************************************/
function ReplaceAll(origString, findString, replaceString) {
    while (origString.search(findString) > 0)
        origString = origString.replace(findString, replaceString);
    return origString;
}


/**********************************************************
 * This function is used for debugging purpose
 **********************************************************/
function displayProperties(obj) {
    var str = ""; var arrProp = new Array();
    var prop;
    var arrIndex = 0;

    if (typeof (obj) == "undefined") {
        alert('displayProperties: Parameter is not an object!');
        return false;
    }

    if (typeof (obj[0]) != "undefined") {
        for (prop = 0; prop < obj.length; prop++) {
            str += "\n" + prop + "=" + obj[prop];
            arrProp[arrIndex++] = "\n" + prop + "=" + obj[prop];
        }
    } else {
        for (prop in obj) {
            str += "\n" + prop + "=" + eval("obj." + prop);
            arrProp[arrIndex++] = "\n" + prop + "=" + obj[prop];
        }
    }
    alert(arrProp.sort());
}

/*********************************************************************************
* Function Name	: showUploadProgress
* Parameters		: -
* Description		: Used to show upload progress bar
* Revision History	: Initial Revision by Paras Shah on 06/sep/2004
*********************************************************************************/
function showUploadProgress() {
    if (Page_ClientValidate()) {
        document.getElementById("lblMessage").style.display = 'none';
        document.getElementById("divUploadProgress").style.display = '';
        return true;
    }
    return false;
}
/*********************************************************************************
* Function Name	: RedirectUser
* Parameters		: -
* Description		: Authorize Page Level Access
* Revision History	: Initial Revision by Nimesh Dhruve on 04/Oct/2004
*********************************************************************************/
function RedirectUser() {
    try {
        //alert('ok');
        var blnValidUser = false;

        //Remove below 2 lines after implementing the security server side
        if (typeof (strAuthorizedUser) == 'undefined')
            blnValidUser = false;

        if (typeof (strAuthorizedUser) != 'undefined' && strAuthorizedUser == true)
            blnValidUser = true;
        if (typeof (parent.strAuthorizedUser) != 'undefined' && parent.strAuthorizedUser == true)
            blnValidUser = true;
        if (typeof (parent.parent.strAuthorizedUser) != 'undefined' && parent.parent.strAuthorizedUser == true)
            blnValidUser = true;
        //	--	http://localhost/Yemo/UM/USR_UserFrameSet.aspx	
        //alert(blnValidUser);
        if (!blnValidUser) {
            //window.location = "/Yemo/UnAuthorizedRequest.aspx";
        }
    } catch (Exc) {
        alert("An error occured while validating user.\nAdditional Details: -\nFunction Name RedirectUser()\nError Message: " + Exc.message);
    }
}

/*********************************************************************************
* Function Name	: checkLength
* Parameters		: oSrc - source control; donot pass; automatically passed by validator
                       args - arguments passed by validator control
* Description		: Custom JS function to check the length of characters in a control; returns false if control
                       contains more characters, otherwise true.  Used when setting property ClientValidationFunction
                       length 1000 hardcoded
* Revision History	: Initial Revision by Murtaza Tinwala on 5-10-04
*********************************************************************************/
function checkLength(oSrc, args) {
    var ctrlObject = document.getElementById(oSrc.getAttribute("controltovalidate"));
    try {
        args.IsValid = false;
        if (typeof (ctrlObject) != 'undefined') {
            var desclength = ctrlObject.value.length;

            if (desclength < 1000) {
                args.IsValid = true;
                return true;
            }
            else {
                args.IsValid = false;
                return false;
            }
        }
        else {
            alert("Unable to find control");
            args.IsValid = false;
            return false;

        }
    } catch (Exc) {
        alert(Exc.message);
    }
}
/*********************************************************************************
* Function Name	: GenerateThumbNail
* Parameters		: strFrameId   - Id of the Iframe in which we want to load thumb nail image.
                     strImagePath - File Path. 
* Revision History	: Initial Revision by Rizwan Mirza on 08-Oct-04
*********************************************************************************/
function GenerateThumbNail(strFrameId, objImageText) {
    try {
        var objFrame = document.getElementById(strFrameId);
        var objFile = document.getElementById(objImageText);
        //parse querystring and pass it to thumbnail generator; is there a better method to retrieve querystring?
        objFrame.src = "../bal/ThumbGenerator.aspx?filename=" + objFile.value;
    } catch (Exc) {
        alert("Unable to generate Thumbnail");
    }
}



function DisableCheckbox(nameOfControl) {
    var ctrl = document.getElementById(nameOfControl);
    if (ctrl != null && ctrl != 'undefined')
        ctrl.checked = false;
}
/***************************************************************************
ChangeSequenceListbox: changes sequence of selected items in the given listbox one place up or down
parameters: 
ctrlName - the name of the listbox control
down - pass true for moving items down, false to up
selectErrorMessage - error message to be shown if no item is selected
***************************************************************************/
function ChangeSequenceListbox(ctrlName, down, selectErrorMessage) {
    ctrl = document.getElementById(ctrlName);
    sl = ctrl.selectedIndex;
    if (sl != -1 && ctrl.options[sl].value > "") {
        if (!down)//move items up
        {
            var oTo = ctrl;
            if (!ctrl.options[0].selected) {
                for (var j = 0; j < ctrl.length; j++) {
                    if (ctrl.options[j].selected && j) {
                        var currText = ctrl.options[j].text;
                        var currValue = ctrl.options[j].value;

                        ctrl.options[j].text = ctrl.options[j - 1].text
                        ctrl.options[j].value = ctrl.options[j - 1].value
                        ctrl.options[j - 1].text = currText;
                        ctrl.options[j - 1].value = currValue;

                        ctrl.options[j - 1].selected = true;
                        ctrl.options[j].selected = false;
                    }
                }
            }
        }
        else //move items down
        {
            var tot = ctrl.options.length;
            if (!tot) return

            for (var j = ctrl.options.length - 1; j > 0 ; j--) {
                if (ctrl.options[j - 1].selected) {
                    var currText = ctrl.options[j].text;
                    var currValue = ctrl.options[j].value;

                    ctrl.options[j].text = ctrl.options[j - 1].text;
                    ctrl.options[j].value = ctrl.options[j - 1].value;
                    ctrl.options[j - 1].text = currText;
                    ctrl.options[j - 1].value = currValue;

                    ctrl.options[j].selected = true;
                    ctrl.options[j - 1].selected = false;
                }
            }
        }
    }
    else {
        alert(selectErrorMessage);
    }
}

/************************************************************************
Selects all items in a listbox
ctrlName - name of listbox
************************************************************************/
function ListboxSelectAll(ctrlName) {
    var lst = document.getElementById(ctrlName);
    for (var i = 0; i <= lst.length - 1; i++)
        lst.options[i].selected = true;
}
/*********************************************************************************
 * Function Name	: startHighlight
 * Parameters		: GridName   - Id of the datagrid on which we want to apply row highlighting					  
 * Revision History	: Initial Revision by Kiran Mistry on 23-August-05
 *********************************************************************************/
function startHighlight(GridName) {
    if (document.all && document.getElementById) {
        navRoot = document.getElementById(GridName);

        // Get a reference to the TBODY element 
        tbody = navRoot.childNodes[0];

        for (i = 1; i < tbody.childNodes.length; i++) {
            node = tbody.childNodes[i];
            if (node.nodeName == "TR") {
                node.onmouseover = function () {
                    this.className = "over";
                }

                node.onmouseout = function () {
                    this.className = this.className.replace("over", "");
                }
            }
        }
    }
}

/***************************************************
function PageQuery(q) 
internal function used to process querystring
***************************************************/
function PageQuery(q) {
    if (q.length > 1)
        this.q = q.substring(1, q.length);
    else
        this.q = null;

    this.keyValuePairs = new Array();

    if (q) {
        for (var i = 0; i < this.q.split("&").length; i++) {
            this.keyValuePairs[i] = this.q.split("&")[i];
        }
    }

    this.getKeyValuePairs = function () {
        return this.keyValuePairs;
    }

    this.getValue = function (s) {
        for (var j = 0; j < this.keyValuePairs.length; j++) {
            if (this.keyValuePairs[j].split("=")[0] == s)
                return this.keyValuePairs[j].split("=")[1];
        }
        return false;
    }

    this.getParameters = function () {
        var a = new Array(this.getLength());
        for (var j = 0; j < this.keyValuePairs.length; j++) {
            a[j] = this.keyValuePairs[j].split("=")[0];
        }
        return a;
    }

    this.getLength = function () {
        return this.keyValuePairs.length;
    }
}


/************************************************************************
function - queryString(key)
processes querystring and returns the given value at client side
************************************************************************/
function queryString(key) {
    var page = new PageQuery(window.location.search);
    return unescape(page.getValue(key));
}



/***************************************************************************
function GetQueryString(varParamNameToGet)
varParamNameToGet - query string variable whose value is sought

This function returns the value of the given querystring variable
****************************************************************************/
function GetQueryString(varParamNameToGet) {
    var strQueryParams = window.location.search;

    if (strQueryParams != "")
        strQueryParams = strQueryParams.substring(1, strQueryParams.length);//remove ?

    strQueryParams = strQueryParams.split('&');

    for (i = 0; i <= strQueryParams.length - 1; i++) {
        var strParamName = strQueryParams[i].split('=')[0];
        var strParamValue = strQueryParams[i].split('=')[1];

        if (strParamName == varParamNameToGet)
            return strParamValue;
    }
}


function removeitem(obj, index) { /* NEW added from version 1.1 */
    obj = (typeof obj == "string") ? document.getElementById(obj) : obj;
    if (obj.tagName.toLowerCase() != "select" || obj.length == 0)
        return;
    if (index === true) {
        for (index = obj.length - 1; index >= 0; index--) {
            if (obj[index].selected) {
                obj[index] = null;
            }
        }
    } else {
        obj[((typeof index != "number") || index > (obj.length - 1) || index < 0 ? obj.length - 1 : index)] = null;
    }
}

/***************************************************************************
function DisplayErrorMsgLightBoxOpen(userDefinedErrorMsg, exceptionErrorMsg)
userDefinedErrorMsg - Get the error string to Display provided by user
exceptionErrorMsg - Get the error string to Display Exception Message
This function Display Message in Lighbox effect when Error Comes
****************************************************************************/
function DisplayErrorMsgLightBoxOpen(userDefinedErrorMsg, exceptionErrorMsg) {
    document.getElementById('light1').style.display = 'block';
    document.getElementById('fade1').style.display = 'block';
    document.getElementById('lbluserDefinedErrorMsg').innerHTML = userDefinedErrorMsg;
    document.getElementById('lblexceptionErrorMsg').innerHTML = exceptionErrorMsg;

}
function DisplayErrorMsgLightBoxClose(doAction) {
    if (doAction == 1) {
        document.getElementById('light1').style.display = 'none';
        document.getElementById('fade1').style.display = 'none';
    }
    if (doAction == 2) {
        window.navigate("../Default.aspx");
    }

}

/***************************************************************************
***************************************************************************/
//For preventing two dots in decimal value
function howManyDecimals(i, color) {

    var Value = document.getElementById(i).value;
    y = Value.split(/\./);
    if (y.length > 2) {
        alert("Invalid Format");
        document.getElementById(i).style.background = "#FFF000";
        document.getElementById(i).value = 0;
    } else {
        document.getElementById(i).style.background = color;
    }

}

/***************************************************************************
For preventing decimal point value
***************************************************************************/
function PreventDecimalPoint(passedEvent) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return true;
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode == 13) )
        return true;
    else
        return false;
}


/***************************************************************************
For preventing decimal point value
***************************************************************************/
function PreventDecimalPointValue(passedEvent) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return true;
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode == 13) || (keyCode == 46))
        return true;
    else
        return false;
}

/***************************************************************************
For multiple contact no
like.. 0265-2555111,2554112
***************************************************************************/
function AllowMultipleContactNo(passedEvent) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return true;
    if ((keyCode >= 48 && keyCode <= 57) || (keyCode == 13) || (keyCode == 44) || (keyCode == 45))
        return true;
    else
        return false;
}
/***************************************************************************
Prevent Space 
like.. 0265-2555111,2554112
***************************************************************************/
function PreventSpace(passedEvent) {
    var objEvent = (passedEvent == null) ? window.event : passedEvent;//for mozilla compatibility
    var keyCode = (navigator.appName == "Netscape") ? objEvent.which : objEvent.keyCode;
    if (keyCode < 30)
        return true;
    if (keyCode == 32)
        return false;
    else
        return true;
}