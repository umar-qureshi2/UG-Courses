
% destination: 192.168.11.13          source: 192.168.11.10

Switch_pings(1)=  8;
Switch_pings(2)=  sum([7 6]);
Switch_pings(3)=  sum([11 9 4]);
Switch_pings(4)=  sum([8 8 9 10]);
Switch_pings(5)=  sum([6 6 10 6 10]);
Switch_pings(6)=  sum([8 10 7 9 2 6]);
Switch_pings(7)=  sum([10 10 8 2 5 6 11]);
Switch_pings(8)=  sum([9 10 2 4 2 4 9 11]);
Switch_pings(9)=  sum([7 9 7 6 3 8 4 10 4]);
Switch_pings(10)= sum([7 9 11 6 3 3 9 8 7 9]);
Switch_pings(11)= sum([8 9 7 7 8 5 9 9 4 10 8]);
Switch_pings(12)= sum([11 8 9 9 6 12 6 2 10 8 9 9]);
Switch_pings(13)= sum([8 10 2 9 9 8 9 2 6 8 4 8 7]);
Switch_pings(14)= sum([7 2 9 5 7 10 9 4 3 8 9 7 6 2]);
Switch_pings(15)= sum([7 2 8 8 9 9 3 2 3 5 10 12 10 3 2]);
Switch_pings(16)= sum([9 7 10 8 3 6 10 9 3 4 10 9 8 8 11 8]);
Switch_pings(17)= sum([8 9 9 8 9 8 9 8 3 7 8 2 9 8 4 10 9]);
Switch_pings(18)= sum([9 7 3 7 3 8 8 4 9 10 9 12 8 6 8 8 6]);
Switch_pings(19)= sum([10 2 6 7 8 7 10 3 9 3 11 4 7 3 10 2 14 8 7]);
Switch_pings(20)= sum([6 3 13 8 8 2 8 10 2 10 8 7 13 11 13 2 8 9 3 7]);

Hub_ping(1)=  7;
Hub_ping(2)=  sum([6 5]);
Hub_ping(3)=  sum([6 3 5]);
Hub_ping(4)=  sum([6 8 5 5]);
Hub_ping(5)=  sum([4 6 6 6 7]);
Hub_ping(6)=  sum([8 5 5 2 8 3]);
Hub_ping(7)=  sum([5 3 2 8 3 8 2]);
Hub_ping(8)=  sum([8 6 7 4 5 7 4 8]);
Hub_ping(9)=  sum([9 6 11 2 5 8 5 2 6]);
Hub_ping(10)= sum([8 7 5 5 6 5 6 6 6 6]);
Hub_ping(11)= sum([7 6 3 7 8 6 6 5 19 5 6]);
Hub_ping(12)= sum([5 5 5 6 2 6 21 5 8 5 2 8]);
Hub_ping(13)= sum([4 4 6 4 7 6 2 8 3 15 3 6 6]);
Hub_ping(14)= sum([7 4 8 6 7 8 7 8 5 4 3 8 7 2]);
Hub_ping(15)= sum([5 4 7 8 5 5 4 8 5 5 3 7 7 8 11]);
Hub_ping(16)= sum([6 6 8 5 6 3 2 5 7 7 8 5 5 8 2 7]);
Hub_ping(17)= sum([5 7 4 13 5 4 3  4 8 5 3 7 5 7 6 17]);
Hub_ping(18)= sum([4 7 3 5 7 6 3 8 5 5 8 5 4 8 7 4 7 7]);
Hub_ping(19)= sum([7 7 6 8 5 10 6 7 2 9 8 6 5 3 7 7 8 8 8]);
Hub_ping(20)= sum([6 4 2 3 8 6 6 4 7 3 5 7 8 6 2 4 4 6 7 5]);

hold on;
plot(1:20,Switch_pings,'.-b');
plot(1:20,Hub_ping,'-r');
legend('Switch','Hub',2)
xlabel('# of Pings');
ylabel('Time (ms)');