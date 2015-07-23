
x=-2*pi:0.3:2*pi;
y=sin(x);

figure(1),subplot(311),plot(x,y,'-k');
title('Actual Function');

Yn = awgn(y,17);

figure(1),subplot(312),plot(x,Yn);
title('Noised Function');

a=ones(1,6).*0.9;
filt=filter(a,4,Yn);

figure(1),subplot(313),plot(x,filt,'-r');
title('Filtered Function');