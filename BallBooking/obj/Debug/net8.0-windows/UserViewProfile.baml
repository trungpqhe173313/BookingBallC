   M S B A M L   `   `   `  ����F  BBallBooking, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BallBookingBallBooking  5   	   !    BallBooking.UserViewProfile   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:BallBooking     5   	     � Title$  UserViewProfile��5   	   $	��450��6!   $	��800��6.   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      $��7* �6   .+�5   
   ]� $��Center=�6   $��5,0,5,0q�6/   $��2��6@   .+�5      � 
����ح�$	��649��6+    5      �� 5      $
��261* �6'   �� 5      $
��134* �6'    � RowDefinitions 5      �� 5      $
��Auto �6%   �� 5      $
��Auto �6%   �� 5      $	��180 �6%   �� 5      $��* �6%   .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�5      $��0, 10, 0, 0q�6(   $��2��6=   .+�5      �� -   5         ��Name$ btnViewBooking��5      $��10q�65   $��80��6A   $��View Booking��6L   6c   �� 5      -   5        $ 	btnLogOut��5      $��10q�60   $��80��6<   $��LogOut��6G   6X   5!      �� 5"      $ Vertical=�6   $
��Left=�5#      $	��500��60   $��2��6<   $��	145,0,0,0q�6P   .+�5$      �� -   5        $��lbTitle��5$      
���  ��$��DemiBold"�6<   $��20(�5%      $��Hồ sơ cá nhân��6"   �� 5'      -   5        $
��lbId��5'      $��FullName��6(   6=   �� 5(      -   5        $��txtName��5(      $��Stretch=�6-   $��25��5)      ��6"   ��  �� Path$ FullName� �� Mode$ OneWay=� � DataContext 5*      ��  �� ElementName$ 	lvMembers��$ SelectedItem��� 5,      -   5        $��
lbFullname��5,      $��Email Address��6.   6H   �� 5-      -   5        $��txtEmail��5-      $��Stretch=�6.   $��25��5.      ��6"   �� $ Email�$ OneWay=� 5/      �� $ 	lvMembers��$ SelectedItem��� 51      -   5        $��lbEmail��51      $��	Telephone��6+   6A   �� 52      -	   5        $��txtPhone��52      $��Stretch=�6.   $��25��53      ��6"   �� $ Username�$ OneWay=� 54      �� $ 	lvMembers��$ SelectedItem�57      �� 59      $ 
Horizontal=�6   $
��Left=�66   $��2��6Q   $��195,342,0,0q�6e   $��2��6z   .+�5:      �� -
   5        $ 	btnUpdate��5:      $��80��60   $��Update��6;   6L   5;      5?      5@      5A      5B      