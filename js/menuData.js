function deep1(no,deep)
{
  if(deep == 10)
    return;
  for(var i=0;i<5;i++)
  {
	switch(no)
	{
      case 2:
        eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','0','','',' Menu "+deep+" "+i+"');"); 
	    break;
 	  default:
		eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','','','',' Menu "+deep+" "+i+"');"); 
	}
       
  }
  deep1(no,++deep);
}
function deep2(par,no,deep)
{ 
  if(deep == 10)
    return;
  var j = Math.round(Math.random()*4);
  for(var i=0;i<5;i++)
  {
    eval(par+".Add(pmL"+no+""+deep+""+i+");");
    if(i== j)
    {  
      var d = deep+1;  
      deep2("pmL"+no+""+deep+""+i,no,d);
    }
  }
}
//xp style
function deep1(no,deep)
{
  if(deep == 10)
    return;
  for(var i=0;i<5;i++)
  {
    switch(no)
    {
      case 2:
        eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','0','','',' Menu "+deep+" "+i+"');"); 
        break;
      default:
            eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','','','',' Menu "+deep+" "+i+"');"); 
    }
       
  }
  deep1(no,++deep);
}        
        
var mm0 = new TMainMenu('mm0','horizontal');
//mm0.SetWidth(500);
//****�w�g Mark by Oscar 2009/05/21 ******//
//var pmselect_area = new TPopMenu('���O','5','','','�|ĳ�O��E�ƥ��x');
//var area_ary = new TPopMenu('Array�|ĳ','','a',"../ary/main.aspx",'Array�|ĳ');
//var area_cell = new TPopMenu('Cell�|ĳ','','a',"../cell/main.aspx",'Cell�|ĳ');
//var area_cf = new TPopMenu('CF�|ĳ','','a',"../cf/main.aspx",'CF�|ĳ');
//var area_Yield = new TPopMenu('Yield�|ĳ','','a',"../Yield/main.aspx",'Yield�|ĳ');
//var area_Productivity = new TPopMenu('PP�|ĳ','','a',"../Productivity/main.aspx",'PP�|ĳ');
//var area_general = new TPopMenu('�@��|ĳ','','a',"../general/main.aspx",'�@��|ĳ');





var pmFileSharing = new TPopMenu('���G��','5','','','���G��');


var pmIcon00 = new TPopMenu('�s�W','','f',"targetWindow('board_add.aspx','mainiframe')",'�s�W');
var pmIcon00_query = new TPopMenu('�d��','','f',"targetWindow('http://t1cimweb01/Onduty_dotnet/top.aspx','mainiframe')",'�d��');
//var pmFav00 = new TPopMenu('Favorites','../img/favorites.gif','','','favorites'); 
//var pmHist00 = new TPopMenu('History','../img/history.gif','','','History');
//var pmHome00 = new TPopMenu('Home','../img/home.gif','','','Home');
//var pmSep00 = new TPopMenu('-','','','','');
//var pmRef00 = new TPopMenu('Refresh','../img/refresh.gif','','','Refresh');
//var pmStop00 = new TPopMenu('Stop','../img/stop.gif','','','Stop');

var pmOpen00 = new TPopMenu('�ȯZ�O��','5','','','�ȯZ�O��');
var onduty_new = new TPopMenu('�s�W','','f',"targetWindow('onduty_add.aspx','mainiframe')",'�ȯZ�O���s�W');
var onduty_query = new TPopMenu('�d��','','f',"targetWindow('onduty_query.aspx','mainiframe')",'�ȯZ�O���d��');
//var pmSame00 = new TPopMenu('in same window','','a','index.html','Open page in same window');
//var pmDiv00 = new TPopMenu('in new window','','f',"targetWindow('index.html','mainiframe')",'Open page in new window');
//var pmL00 = new TPopMenu('Long popup menu','','','','Popup menu demo');



var E_Meeting_function_list = new TPopMenu('�����s��','','','','�����s��');

var E_Meeting_function_homepage = new TPopMenu('�оǤ��U��','','f',"newWindow('C3_Onduty_Web_intro.ppt','mainiframe')",'�оǤ��U��');

var E_Meeting_function_ars_link= new TPopMenu('ARS LINK','','f',"newWindow('http://t1ars:8000/ARS/Login.php','mainiframe')",'ARS LINK');

var E_Meeting_function_checkView= new TPopMenu('Check View','','f',"newWindow('http://10.56.131.22/onduty_dotnet/Onduty_check/show_login.aspx','mainiframe')",'Check View');

var E_Meeting_function_OnePage= new TPopMenu('CIM�ȯZ�ɼƪ� One Page �g�έp','','f',"newWindow('http://t1cimweb01/daily_check_alarm/onduty_integrated.aspx','mainiframe')",'CIM�ȯZ�ɼƪ� One Page �g�έp');

var E_Meeting_function_Report_interval= new TPopMenu('�d��Report ���� Interval Time','','f',"newWindow('http://10.56.131.22/E-FAB_dotnet/report_creat_time.aspx','mainiframe')",'�d��Report ���� Interval Time');



//var E_Meeting_function_Query = new TPopMenu('�ɮ׷j�M','','f',"targetWindow('e_meeting_query.aspx','mainiframe')",'E-Meeting �W�Ƿj�M');
//var E_Meeting_function_upload= new TPopMenu('�ɮפW��','','f',"targetWindow('e_meeting_upload.aspx','mainiframe')",'E-Meeting �ɮפW��');


//var pmDocument_List = new TPopMenu('�оǤ��','','f',"targetWindow('teaching_document.aspx','mainiframe')",'�оǤ��');


//var pmDocument = new TPopMenu('�оǬ�����T','','',"targetWindow('mail_meeting.aspx','mainiframe')",'�оǬ�����T');
//var pmDocument_List = new TPopMenu('�оǤ��','','f',"targetWindow('sop.doc','mainiframe')",'�оǤ��');

//var login_history = new TPopMenu('�έp','','','','�έp');
//var login_history_web = new TPopMenu('�n�J�έp','','f',"targetWindow('statistic_login.aspx','mainiframe')",'�n�J�έp');
//var Meeting_type_statistic = new TPopMenu('Meeting_Type�έp','','f',"targetWindow('statistic_meeting_type.aspx','mainiframe')",'�n�J�έp');




//var pmDocument_NetMeetingConfig = new TPopMenu('NetMeeting�w�˳]�w'Add,'','f',"targetWindow('/Distance/Document_Link/NETMEETING_INST/netmeet_config.htm','mainiframe')",'NetMeeting�]�w');

//var pmTrustView = new TPopMenu('TrustView System','','f',"newWindow('http://inlcndrm01/innolux/')",'�[�K����');
//var pmDistance_Intro = new TPopMenu('���Z�оǥ��x����','','f',"targetWindow('/Distance/Document_Link/Distance_Intro/Distance_Introduction.htm','mainiframe')",'���Z�оǥ��x����');


//var pmInnoWiki = new TPopMenu('InnoWiki�s�Цʬ�','','','','InnoWiki�s�Цʬ�');

//var pmInnoWiki_Main = new TPopMenu('InnoWiki����','','f',"newWindow('InnoWiki.aspx','mainiframe')",'InnoWiki����');
//var pmInnoWiki_Intro = new TPopMenu('InnoWiki�t�Τ���','','f',"newWindow('InnoWiki_Intro.aspx','mainiframe')",'InnoWiki�t�Τ���');

//var pmAbout00 = new TPopMenu('About','','f',"alert('Implement by Bunny')",'About this program');
//var pmAbout00 = new TPopMenu('About','','f',"alert('Implement by Bunny')",'About this program');


//�s�W�n�J���O****�w�g ��X mark ��  oscar 2009/05/21 ******//
//mm0.Add(pmselect_area);
//pmselect_area.Add(area_ary);
//pmselect_area.Add(area_cell);
//pmselect_area.Add(area_cf);
//pmselect_area.Add(area_Yield);
//pmselect_area.Add(area_Productivity);
//pmselect_area.Add(area_general);




//Meeting System Function (Meeting System)
mm0.Add(pmFileSharing);
mm0.Add(pmOpen00);


pmFileSharing.Add(pmIcon00);
pmFileSharing.Add(pmIcon00_query);

//pmFileSharing.Add(pmDocument_List);




//E-Meeting Combine(E-Meeting Combine)
mm0.Add( E_Meeting_function_list);
E_Meeting_function_list.Add(E_Meeting_function_homepage);
E_Meeting_function_list.Add(E_Meeting_function_ars_link);
E_Meeting_function_list.Add(E_Meeting_function_checkView);
E_Meeting_function_list.Add(E_Meeting_function_OnePage);
E_Meeting_function_list.Add(E_Meeting_function_Report_interval);







//E_Meeting_function_list.Add(E_Meeting_function_Query);
//E_Meeting_function_list.Add(E_Meeting_function_upload);

//mm0.Add(login_history);
//login_history.Add(login_history_web);
//login_history.Add(Meeting_type_statistic);

pmOpen00.Add(onduty_new);
pmOpen00.Add(onduty_query);







//�|ĳ�O���оǤ��(pmDocument)
//mm0.Add(pmDocument);
//pmDocument.Add(pmDocument_List);
//pmDocument_List.Add(pmDocument_NetMeetingConfig);


//pmDocument_List.Add(pmDistance_Intro);
//pmDocument.Add(pmDocument_WebSite);

//pmIcon00.Add(pmFav00);
//pmIcon00.Add(pmHist00);
//pmIcon00.Add(pmHome00);
//pmIcon00.Add(pmSep00);
//pmIcon00.Add(pmRef00);
//pmIcon00.Add(pmStop00);
//pmDemo00.Add(pmSep00);

//pmOpen00.Add(pmSame00);
//pmOpen00.Add(pmDiv00);
//pmDemo00.Add(pmL00);

//InnoWiki�s�Цʬ�
//mm0.Add(pmInnoWiki);
//pmInnoWiki.Add(pmInnoWiki_Main);
//pmInnoWiki.Add(pmInnoWiki_Intro);
//pmAlert00.Add(pmAbout00);
//mm0.Add(pmGoToMainPage);

//pmHelp00.Add(pmAbout00);
//end of xp style      