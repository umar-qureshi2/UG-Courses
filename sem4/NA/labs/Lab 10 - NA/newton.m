function [k,p0,inc,y] = newton(f,p0,delta,max1)
% Input
% - f is the function 
% - p0 is the initial approximation
% - delta is the tolerance for increment
% - max1 is the maximum number of iterations
% Output 
% - k is the number of iteration
% - p0 is the Newton approximation to the zero
% - inc is the final value of f(p0)/f’(p0)
% - y is the value of function at p0 i.e. f(p0)
% function call [k,p0,inc,y] = newton('f1',1,1e-6,100)
fprintf('k\t\t\t  seq of p0\t\t\tIncrement\t\t value f(p0)\n')
for k=1:max1
    [fv,dfv]=feval(f,p0);
    if dfv==0 
        disp('Division by zero occured')
        inc=NaN; y=NaN;
        break;
    end
    inc=fv/dfv;
    p0=p0-inc;  y=fv;
    fprintf('%d \t\t %15.12f\t%15.12f\t%15.12f\n',k,p0,inc,y);
    if abs(inc)<delta
       break;
   end
end
if k == max1
   disp('maximum number of iterations exceeded')
end

function [y,dy]=f1(x)
    y=x.^2-9;
    dy=2*x;
 