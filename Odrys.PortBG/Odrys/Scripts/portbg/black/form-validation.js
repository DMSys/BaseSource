function check_it()
{
	var complete = true;
	var str      = "";
	var thename  = document.contact.author.value;
    if ((thename == "") || (thename == null))
    {
      str = str + "Името в полето е празно. ";
      complete = false;
	}
	
	var email_ad = document.contact.email.value;
	if ((email_ad.indexOf("@") ==-1) || (email_ad.indexOf(".") ==-1))
	{
	   str = str + "Email адреса не е валиден. ";
	   complete = false;
	}
	
	var subject_ad = document.contact.subject.value;
	if ((subject_ad == "") || (subject_ad == null))
	{
	   str = str + "Полето за относно не е попълнено. ";
	   complete = false;
	}
	
	if (complete == true) 
	{
	  alert("Съобщението е изпратено успешно!");
	}
	 
	 if (str != "") 
	{
	  alert(str + "Моля попълнете празните полета!");
	}
	
    return complete;
}