function [k,c,err,yc]=regula(f,a,b,delta,epsilon,max1)
%Input    - f is the function 
%	- a and b are the left and right endpoints
%	         - delta is the tolerance for the zero
%	         - epsilon is the tolerance for the value of f at the zero
%	         - max1 is the maximum number of iterations
%Output - c is the zero
%	         - yc=f(c)
%	         - err is the error estimate for c
ya=feval(f,a);
yb=feval(f,b);
if (ya*yb)>0
	disp('Note: f(a)*f(b)>0'),
	return,
end
fprintf('\t\t\tLeft\t\t\t\t\t\t\tRight\t\tFun Value\n')
fprintf('k\t\t  endpoint\t\t  Midpoint\t\t\tendpoint\t\tf(c)\n')
for k=1:max1
	c=(a*yb-b*ya)/(yb-ya);
	yc=feval(f,c);
    fprintf('%d \t\t %f\t%15.8f\t%15.8f\t%15.8f\n',k,a,c,b,yc);
    if abs(min((b-c),(a-c)))<delta & (abs(yc)<epsilon)
         disp('Breaking condition is met')        
         break; 
     end
    if yc==0,break;
	elseif yb*yc>0
		b=c;
		yb=yc;
	else
		a=c;
		ya=yc;
    end
end
c;
err=abs(min((b-c),(a-c)));
yc=feval(f,c);