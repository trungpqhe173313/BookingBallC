   M S B A M L   `   `   `  ����F  BBallBooking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BallBookingBallBooking  5   	   !    BallBooking.BookFieldWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BallBooking     5   	     � Title$  BookFieldWindow��5   	   $	��850��6!   $	��800��6.   .��5	      � $��	0,0,0,-36q�6    � RowDefinitions 5
   
   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��38* �6   �� 5      $
��308* �6   �� 5      $
��319* �6   �� 5      $
��110* �6   �� 5      $	��25* �6   .+�5   
   ]� $	��Top=�6   $��5,0,5,0q�6,   $��5��6=   $��2��6Q   .+�5      � 
����ح�$	��800��6*    J� RenderTransformOrigin$ 
0.49,0.841&�67   $	��774��6Z    5      �� 5      $��43.74 �6$   �� 5      $	��180 �6$   �� 5      $	��121 �6$   �� 5      $
��Auto �6$   $��69��62   �� 5      $��85.248 �6$   �� 5      .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�64   $��	0,10,0,16q�6O   $��4��6b   $	��100��6s   .+�5       �� -   5         ��Name$ btnField��5       $��10q�6/   $��80��6;   $��Quản lý sân��6F   6\   �� 5!      -   5        $ 	btnLogOut��5!      $��10q�60   $��80��6<   $��LogOut��6G   6X   5"      �� 5#      $ Vertical=�6   $��Center=�64   $	��500��6Q   $��4��6]   $��0,0,0,16q�6n   .+�5$      �� -   5        $��lbTitle��5$      
���  ��$��DemiBold"�6<   $��20(�6R   $��Booking��6`   �� 5%      $��Số điện thoại��6   �� 5&      -   5        $��tbPhone��5&      $��Stretch=�6-   $��25��6K   �� 5'      -   5        $��lbField��5'      $��Sân ��6+   �� 5(      -   5        $��cbField��5(       �� DisplayMemberPath$ 	FieldName��6.   $��Stretch=�6L   5*      �� 5+      $��Ngày đặt��6   (  "System.Windows.Controls.DatePicker  5,      -   5          Name$ dpDate��5,   !   $��25��61   �� 5-      -   5        $��lbStartDate��5-      $��Thời gian bắt đầu��6/   �� 5.      -	   5         ��Name$ tbStartTime��5.      $��0q�63   $��25��6>   �� 5/      -
   5        $��	lbEndDate��5/      $��Thời gian kết thúc��6-   �� 50      -   5        $ 	tbEndTime��50      $��0q�62   $��25��6=   �� 51      $��Giá 1 giờ��6   �� 52      -   5        $��tbPrice��52      $��Stretch=�6-   $��25��6K   53      �� 54      $��2��6   $ 
Horizontal=�6*   $��Center=�6C   $��
0,150,0,16q�6`   $��2��6t   $	��170��6�   .+�55      �� -   5        $ 	btnUpdate��55      $��10q�60   $��80��6<   $��Update��6G   $��21��6Y   6e   �� 56      -   5        $ btnAdd��56      $��69��6-   $	��Add��68   $��21��6[   59      &   System.Windows.Controls.DataGrid  5:      -   5        	  Name$	 	dgBooking��5:   (   $��4��6   $
��Auto��6;   $	��261��6H   $��
22,37,10,0q�6U   $	��Top=�6i   $ 0.489,1.069&�5;      $��2��6,   
   AutoGenerateColumns$
 False��5<      $   HorizontalScrollBarVisibility$
 Auto=�6#      Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ UserID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 70 6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   ��  �� Path$ UserId�  5@      $ 
Field Name��6-   $ 70 6A    6L   �� $ Field.FieldName�  5A      $ BookingDate��6-   $	 120 6B    6N   �� $ BookingDate�  5B      $ 	StartTime��6-   $	 120 6@    6L   �� $ 	StartTime�  5C      $ EndTime��6-   $	 150 6>    6J   �� $ EndTime�  5D      $ Status��6-   $	 100 6=    6I   �� $ Status.StatusName�  5E      $ Total Price��6-   $	 150 6B    6N   �� $ 
TotalPrice�5G      �� 5H      -   5        $ btnClose��5H   &   $��5��6   $��0,231,59,45q�68   $��Right=�6M   $��86��6i   $��Close��6t   $ 0.154,3.127&�6�   6�   �� 5I      -   5        $ btnClear��5I      $��Clear��6+   $
��Left=�6;   $��
490,22,0,0q�6V   $��3��6j   $	��Top=�6w   $��62��6�   $��21��6�   6�   �� 5J      -   5        $ 	btnCancel��5J      $��Cancel��6,   $
��Left=�6=   $��
570,22,0,0q�6X   $��3��6l   $	��Top=�6y   $��62��6�   $��21��6�   6�   5K      5L      5M      5N      