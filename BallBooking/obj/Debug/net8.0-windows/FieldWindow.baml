   M S B A M L   `   `   `  ����F  BBallBooking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BallBookingBallBooking  5   	       BallBooking.FieldWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BallBooking     5   	     � Title$  FieldWindow��5   	   $	��700��6   $	��820��6*   .��5	      � $��	0,0,0,-36q�6    � RowDefinitions 5
   
   �� 5      �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $	��38* �6   �� 5      $
��308* �6   �� 5      $
��319* �6   �� 5      $
��110* �6   �� 5      $	��25* �6   .+�5   
   ]� $	��Top=�6   $��5,0,5,0q�6,   $��5��6=   $��2��6Q   .+�5      � 
����ح�$	��666��6*    J� RenderTransformOrigin$ 
0.49,0.841&�67   $	��786��6Z    5      �� 5      $��43.74 �6$   �� 5      $	��180 �6$   �� 5      $��20 �6$   �� 5      $
��Auto �6$   $��72��62   �� 5      $��223.248 �6$   �� 5      .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�64   $��	0,10,0,16q�6O   $��4��6b   $	��100��6s   .+�5       �� -   5         ��Name$ 
btnBooking��5       $��10q�61   $��80��6=   $��Quản lý lịch��6H   6_   �� 5!      -   5        $ 	btnLogOut��5!      $��10q�60   $��80��6<   $��LogOut��6G   6X   5"      �� 5#      $ Vertical=�6   $��Center=�64   $	��500��6Q   $��4��6]   $��0,0,0,16q�6n   .+�5$      �� -   5        $��lbTitle��5$      
���  ��$��DemiBold"�6<   $��20(�6R   $��Field��6`   �� 5%      $��	Tên sân��6   �� 5&      -   5        $��tbField��5&      $��Stretch=�6-   $��25��6K   �� 5)      $��Địa chỉ��6   �� 5*      -   5         ��Name$ 
tbLocation��5*      $��0q�62   $��25��6=   �� 5+      $��Mô tả��6   �� 5,      -   5        $ tbDescription��5,      $��0q�66   $��25��6A   �� 5-      $��Giá 1 giờ��6   �� 5.      -   5        $��tbPricePerHour��5.      $��Stretch=�64   $��25��6R   5/      �� 50      $��3��6   $ 
Horizontal=�6*   $��Center=�6C   $��	0,10,0,16q�6`   $	��170��6s   .+�51      �� -   5        $ 	btnUpdate��51      $��10q�60   $��80��6<   $��Update��6G   $��21��6Y   6e   �� 52      -	   5        $ btnAdd��52      $��69��6-   $	��Add��68   $��21��6G   6S   55      &   System.Windows.Controls.DataGrid  56      -
   5          Name$ dgField��56   (   $��4��6   $
��Auto��69   $	��261��6F   $��
10,37,10,0q�6S   $	��Top=�6g   $ 0.489,1.069&�57      $��2��6(      AutoGenerateColumns$ False��58      $	   HorizontalScrollBarVisibility$
	 Auto=�6   
   Columns
 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ FieldID��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   ��  �� Path$ FieldId�  5<      $ 
Field Name��6-   $
 1.5* 6B    6O   �� $ 	FieldName�  5=      $ Location��6-   $ 3* 6?    6J   �� $ Location�  5>      $ Description��6-   $ 3* 6C    6N   �� $ Description�  5?      $ PricePerHour��6-   $ 1* 6D    6O   �� $ PricePerHour�5A      �� 5C      -   5        $ btnClose��5C   &   $��5��6   $��0,231,59,30q�68   $��Right=�6M   $��86��6i   $��Close��6t   $ 0.154,3.127&�6�   �� 5D      -   5        $ btnClear��5D      $��Clear��6+   $
��Left=�6;   $��
496,22,0,0q�6V   $��3��6j   $	��Top=�6w   $��62��6�   $��21��6�   6�   �� 5E      -   5        $ 	btnDelete��5E      $��Delete��6,   $
��Left=�6=   $��
575,22,0,0q�6X   $��3��6l   $	��Top=�6y   $��62��6�   $��21��6�   6�   5F      5G      5H      5I      