   M S B A M L   `   `   `  ����E  ADemoEFCore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DemoEFCore
DemoEFCore  5   	       DemoEFCore.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DemoEFCore     5   	   -   5          � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ShowGridLines$
 True��6   $��10q�6     � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5       � RowDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��8* �6   �� 5      $��1* �6   .+�5   
   ��    textblockStyle#��[  6   $��0��6<   $��0��6L   Mã loại sản phẩm:6l   �� 5   
   -   5        $��inputId��5   8     textboxStyle#��[ 6   $��1��6G   $��0��6W   �� 5   
   #��[  6   $��0��6=   $��1��6M   Tên loại sản phẩm:6n   �� 5   
   -   5        $��	inputName��5   8   #��[ 6   $��1��6I   $��1��6Y   &   System.Windows.Controls.DataGrid  5   
   -   5        $��products��5   V      AlternatingRowBackground
 ��ح�$��1��68   $��2��6H      AutoGenerateColumns$ False��6f     columnHeaderStyle   ColumnHeaderStyle# [ 6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ MaLoai��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 * 6P   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 65   �� *MaLoai+6P     5      $ TenLoai��6%   $	 * 6R   
 66   �� *	TenLoai+6R   5       �� 5"   
   $��2��6   $��3��6)    �� Orientation$ 
Horizontal=�66   $��Center=�6O   $��Center=�6j   .+�5#      �� -   5          buttonStyle#��[ 5#      .��6O   Thêm6U   �� 5$      -   5        #��[ 5$      .��6Q   Sửa6V   �� 5%      -   5        #��[ 5%      .��6Q   Xóa6V   �� 5&      -   5        #��[ 5&      .��6Q   Thoát6X   5'      5(      5)      