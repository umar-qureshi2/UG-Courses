////////////////////////////////////////////////////////////////////////////////
// contains common js functions that most of the page will use
//
////////////////////////////////////////////////////////////////////////////////
function MTest()
{
   alert('INSIDE common.js MTEST() function called!!');
}
//---------------------------------------------------------------------------
function RandomNumber( min, max )
{
    return (Math.round((max-min) * Math.random() + min));
}
//---------------------------------------------------------------------------
function Trim(s) 
{
  // Remove leading spaces and carriage returns
  while((s.substring(0,1)==' ')||(s.substring(0,1)=='\n')||
		  (s.substring(0,1)=='\r'))
  {
    s = s.substring(1,s.length);
  }

  while((s.substring(s.length-1,s.length)==' ')||
		  (s.substring(s.length-1,s.length)=='\n')||
		  (s.substring(s.length-1,s.length)=='\r'))
  {
    s = s.substring(0,s.length-1);
  }
  return s;
}
//---------------------------------------------------------------------------
function TrimAll(v) 
{
	temp="";
	x=0;
	while (x<v.length){
		c = v.charAt(x); 
		if( c != ' ' && c != '\n' && c!= '\r' && c != '\t') temp+=(v.charAt(x));
		x++;
	}
	return temp;
}
//---------------------------------------------------------------------------
function gcd(a,b)
{
	if(a == 0) {return b;};
	if(b == 0) {return a;};
	var temp;
	if(a < 0) {a = -a;};
	if(b < 0) {b = -b;};
	if(b > a) {temp = a; a = b; b = temp;};
	var c = 0;
	while ( c < 10000) {
		c++;
		a %= b;
		if(a == 0) {return b;};
		b %= a;
		if(b == 0) {return a;};
	};
	if (c == 10000){
		alert(" Hmmmm excedded a="+a + " b="+b);
	}
	return b;
}
//---------------------------------------------------------------------------
function MulInv(a,b)
{
	g = gcd(a,b);
	if ( g != 1)
		return -1;					  // Mul Inv does not exist
	for (i=1; i < b; i++){
		r = (a * i) % b;
		if (r == 1)
			return i;
	}
}
//---------------------------------------------------------------------------
var NS4 = false;
var IE  = false;
var ver = 0.0;

if(parseInt(navigator.appVersion) >= 4 && navigator.appName == 'Netscape')
{
  NS4 = true;
  var versionBegin = version.indexOf("'Netscape'") + 5;
  var versionEnd = version.indexOf(";", versionBegin);
  var versionNum = version.substring(versionBegin, versionEnd);
  var versionNumF = parseFloat (versionNum);

  ver = versionNumF;
}
else if (navigator.appName == 'Microsoft Internet Explorer') 
{
  IE =true;
  var version = navigator.appVersion;
  var versionBegin = version.indexOf("MSIE") + 5;
  var versionEnd = version.indexOf(";", versionBegin);
  var versionNum = version.substring(versionBegin, versionEnd);
  var versionNumF = parseFloat (versionNum);

  ver = versionNumF;
}
////////////////////////////////////////////////////////////////////////////////
function getCookieVal (offset) 
{
  var endstr = document.cookie.indexOf (";", offset);
  if (endstr == -1)
    endstr = document.cookie.length;
  return unescape(document.cookie.substring(offset, endstr));
}

function GetCookie (name) 
{
  var arg = name + "=";
  var alen = arg.length;
  var clen = document.cookie.length;
  var i = 0;
  while (i < clen)
  {
    var j = i + alen;
    if (document.cookie.substring(i, j) == arg)
      return getCookieVal (j);
    i = document.cookie.indexOf(" ", i) + 1;
    if (i == 0) break; 
  }
  return null;
}

function SetCookie (name, value) 
{
  var argv = SetCookie.arguments;
  var argc = SetCookie.arguments.length;
  var expires = (argc > 2) ? argv[2] : null;
  var path = (argc > 3) ? argv[3] : null;
  var domain = (argc > 4) ? argv[4] : null;
  var secure = (argc > 5) ? argv[5] : false;
  document.cookie = name + "=" + escape (value) +
    ((expires == null) ? "" : ("; expires=" + expires.toGMTString())) +
    ((path == null) ? "" : ("; path=" + path)) +
    ((domain == null) ? "" : ("; domain=" + domain)) +
    ((secure == true) ? "; secure" : "");
}
////////////////////////////////////////////////////////////////////////////////

function WriteDateTime() 
{
  var dttm= Date();
  document.write(dttm);
}
//---------------------------------------------------------------------------
function FIND(item) {
   if (document.getElementById) return(document.getElementById(item));
   else if (document.all) return(document.all[item]);
   return(false);
}
