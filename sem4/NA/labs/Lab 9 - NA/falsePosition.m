function [k c err yc] = falsePosition(f,a,b,delta,epsilon,max1)

ya = feval(f,a);    yb = feval(f,b);    c = (a*yb - b*ya)/(yb - ya);    yc=feval(f,c);
err = abs(min((b-c),(a-c)));

if ya*yb>=0
	fprintf('The root is not lying in interval')
	return
end

for k=1:max1
    c = (a*yb - b*ya)/(yb - ya);
    yc = feval(f,c);
    
    fprintf('%d \t %15.8f\t%15.8f\t%15.8f\t%15.8f\n',k,a,c,b,yc);
    
    if(abs(min((b-c),(a-c))) < delta)
        break;
    end

    if(abs(yc) < epsilon)
        break;
    end
    
    if yc==0
        a=c;    b=c;
    elseif yb*yc>0
        b=c;    yb=yc;
    else
        a=c;    ya=yc;
    end

end

    if yc==0
        a=c;    b=c;
    elseif yb*yc>0
        b=c;    yb=yc;
    else
        a=c;    ya=yc;
    end

k= k+1; c = (a*yb - b*ya)/(yb - ya);    yc = feval(f,c);    err = abs(min((b-c),(a-c)));

fprintf('%d \t %15.8f\t%15.8f\t%15.8f\t%15.8f\n',k,a,c,b,yc);
