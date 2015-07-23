x=[-pi:0.05:pi];
f=sin(x);
z=awgn(f,25);
b=filter(ones(1,5)/5,1,z);

subplot(3,1,1);plot(f)
title('Original Function')
subplot(3,1,2);plot(z)
title('Noisy Function')
subplot(3,1,3);plot(b)
title('Filtered Function')