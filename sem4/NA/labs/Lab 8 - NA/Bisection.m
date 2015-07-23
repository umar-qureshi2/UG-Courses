function [k,c,err,yc]=Bisection(f,a,b,delta)
%Input - f is the fun  - delta is the tolerance  - a and b are the left and right endpoints   
%Output - c is the zero         - yc= f(c)            - err is the error estimate for c
ya=feval(f,a);  yb=feval(f,b); c=(a+b)/2; err=abs(b-a); yc=feval(f,c);
if ya*yb>=0
	fprintf('The root is not lying in interval')
	return
end
max1=1+round((log(b-a)-log(delta))/log(2));
fprintf('\t\t\tLeft\t\t\t\t\t\t\tRight\t\tFun Value\n\n')
fprintf('k\t\t  endpoint\t\t     Midpoint\t\t  endpoint\t\tf(c)\n')
for k=1:max1
    c=(a+b)/2; yc=feval(f,c);
    fprintf('%d \t %15.8f\t%15.8f\t%15.8f\t%15.8f\n',k,a,c,b,yc);
    if yc==0
        a=c;    b=c;
    elseif yb*yc>0
        b=c;    yb=yc;
    else
        a=c;    ya=yc;
    end
    if b-a < delta, break, end
end
c=(a+b)/2;	err=abs(b-a);	yc=feval(f,c);
