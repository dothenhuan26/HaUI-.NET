   M S B A M L   `   `   `  ����I  EDoTheNhuan_381, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:DoTheNhuan_381DoTheNhuan_381  5   	       DoTheNhuan_381.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:DoTheNhuan_381     5   	   -   5          � Title$  
MainWindow��5	   	   $	��600��6   $	��800��6)   .��5
      �  � ShowGridLines$ False��6   $��10q�6!    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5   
   ��    TextBlockStyle#��[  6   $��0��6<   $��0��6L   Mã bệnh nhân:6h   �� 5   
   #��[  6   $��0��6<   $��1��6L   
Họ tên:6b   �� 5   
   #��[  6   $��0��6<   $��2��6L   Địa chỉ:6c   �� 5   
   #��[  6   $��0��6<   $��3��6L   Số ngày nằm viện:6l   �� 5   
   #��[  6   $��0��6<   $��4��6L   Khoa khám:6e   �� 5   
   -   5         ��Name$ inputId��5        TextBoxStyle#��[ 6#   $	��150��6I   $��1��6U   $��0��6e   6t   �� 5    
   -   5        $ 	inputName��5       #��[ 6%   $	��200��6K   $��1��6W   $��1��6g   6v   �� 5!   
   -   5        $ inputAddress��5!      #��[ 6(   $	��150��6N   $��1��6Z   $��2��6j   6y   �� 5"   
   -   5        $ 	inputDays��5"      #��[ 6%   $	��150��6K   $��1��6W   $��3��6g   6v   �� 5#   
   -   5         ��Name$ inputDepartment��5#      $
��Left=�6,   $��Center=�6G   $��10q�6b   $��	10,5,10,5q�6n   $��1��6�   $��4��6�   $	��200��6�   6�   &   System.Windows.Controls.DataGrid  5%   
   -   5          Name$ 
renderData��5%      $��5��6'   $��2��64      AutoGenerateColumns$ False��6H     ColumnHeaderStyle   ColumnHeaderStyle# [ 6d   	   Columns	 5&      0  *System.Windows.Controls.DataGridTextColumn  5'      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6%      Header$ Mã bệnh nhân��6H   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6/   �� *Mabn+6H     5(      $
 * 6%   $ 	Họ tên��6I    6/   �� *Hoten+6I     5)      $
 * 6%   $ Mã khoa��6J    6/   �� *Makhoa+6J     5*      $
 * 6%   $ Địa chỉ��6J    6/   �� *Diachi+6J     5+      $
 * 6%   $ Số ngày nằm viện��6L    6/   �� *
SongayNv+6L     5,      $
 * 6%     ColumnTextStyle   	CellStyle# [ 6K   $ Viện phí��6x    6/   �� *	VienPhi+6x   5.      �� 50   
   $��Center=�6    �� Orientation$ 
Horizontal=�62   $��Center=�6K   $��6��6f   $��2��6s   .+�51      �� -   5          ButtonStyle#��[ 51        ButtonTemplate#��[ 6:   .��6z   Thêm6�   �� 52      -	   5        #��[ 52      #��[ 6:   .��6|   Sửa6�   �� 53      -
   5        #��[ 53      #��[ 6:   .��6|   Xóa6�   �� 54      -   5        #��[ 54      #��[ 6:   .��6|   Thống kê6�   55      57      58      