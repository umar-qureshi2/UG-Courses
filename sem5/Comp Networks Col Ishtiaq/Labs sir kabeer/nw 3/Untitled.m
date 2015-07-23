time_of_hub=[6 5 6 6 5];
time_of_switch=[8 8 8 7 7];
packet=10:5:30;
plot(packet,time_of_hub)
hold on 
plot(packet,time_of_switch,'r')
xlabel('Packet');
ylabel('Time taken');
grid;
