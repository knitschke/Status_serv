   M S B A M L   `   `   `  ����F  BStanDysków, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:StanDyskówStanDysków  5   	       StanDysków.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:StanDysków     5   	     � Title$  StanSerw��5   	   $	��350��6   $	��300��6'    � WindowStartupLocation$ CenterScreen=�63   .��5	      � $��0,0,0,0q�6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    � MappingMode$ RelativeToBoundingBox=�63    �� 
StartPoint$ 0.5,0&�6W   .��5      �  � Color$ Black��6   � 5      $ 	#FFD5F4F7��6    � Offset$ 0.161Q�61   5       � ColumnDefinitions 5   
   �� 5      $��8 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��8 �6    � RowDefinitions 5   
   �� 5      $��20 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��40 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��8 �6   .+�5!   
   �� -   5        	 ��Name$
	 Scan��5!      $	��100��6   $��3��6.   $��5��6B   $��Skanuj��6O   $��1��6`   $��Center=�6p   $��0,0,0,0q�6�   $��Center=�6�   6�   �� 5"   
   -   5        
 ��Name$

 Mail��5"      $��2��6    $��3��6-   $��1��6A   $��Center=�6Q   $��0,0,0,0q�6n   $��Center=�6   $��x.y@powiat.poznan.pl��6�   �� 5#   
   -   5        $	 Database��5#      $	��100��6#   $��6��62   $��Baza Danych��6?   $��1��6U   $��Center=�6e   $��Center=�6�   $��3��6�   6�   G� 5$   
   -   5         G�Name$
 Pswd��5$      $	��100��6$   $��3��63   $��4��6H   $��1��6U   $��Center=�6e   $��0,0,0,0q�6�   $��Center=�6�   �� 5%   
   $��Email:��6   $��1��6!   $��2��6.   $��Center=�6>   $��0,0,0,0q�6[   $��Center=�6l   �� 5&   
   $��Hasło:��6   $��3��6!   $��2��6.   $��Center=�6>   $��0,0,0,0q�6[   $��Center=�6l   5(      5)      