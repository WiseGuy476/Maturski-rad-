   M S B A M L   `   `   `  ����A  =Login2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Login2Login2  5   	       Login2.Informacije   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	    localclr-namespace:Login2  5   	   -   5          � Title$  Informacije��5	   	   $	��570��6   $	��900��6*    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	    � 	Resources 5       �� MergedDictionaries �� Source&   System.Windows.Controls.DataGrid �� 
TargetType �� Property	 �� Value)  #System.Windows.Controls.DataGridRow
 �� Triggers P� Property P� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType �� Padding�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Lime.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %4  '        �� 5      "  6   .�5      ��  � ��	 �#DDDDDD60   �� 5        �@ HorizontalGridLinesBrush	 �#DDDDDD6=   �� 5       �@ VerticalGridLinesBrush	 �#DDDDDD6;   �� 5       �@ RowStyle	 5      �� 5       "  6    
 5!      P� 5#   "    �@J�IsMouseOver . . �5$   &   ��  � ��
	 �����6C   5%   #   5'      5)      �� 5*       �@ 	CellStyle	 5+      �� 5,      "  6    
 5-      P� 5/   "    �@ 
IsSelected . . �50   &   ��  � ��	 �	#ff66ccff6C   �� 51   &    � ��
	 ���� 6D   �� 52   &    � ��	 �#0033666C   53   #   P� 54   "    �@J�	IsFocused . . �55   &   ��  � ��	 �	#ff66ccff6C   �� 56   &    � ��	 �#0033666D   �� 57   &    � ��$	 1q�6H   �� 58   &    � ��	 �#0033666C   59   #   .�5<      ��  � ��$	 4,3,4,3q�68   �� 5=       � ��
	 ���� 6<   �� 5>       � ��$	 1q�6@   �� 5?       � ��	 5@   "   �� 5A   &   "  66   .R�5B   *   �� # z��61   #��z��5C   -   #��z��5D   -   #��z��5E   -   ._�5F   .   �� 5G   +   5H   '   5J      �� 5K       �@�FocusVisualStyle	 5L   "   �� 5M   &   " ��6,   .�5N   *   ��  � ��
	 ���� 6H   5O   '   5Q      5R      5T      5U      5V      .��5X      � ��5Y   
   �� 5Z       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5[      �  � Color$ #FADA5E��6   � 5\      $ #bdc3c7��6    � Offset$	 0.9Q�6/   5]      .+�5_   
   �� -   5         ��Name$ buttonZatvori��5_      $	��✖��6D   $��0q�6P   $��29��6\   $��30��6h   $��Right=�6t   ���#003366���#bdc3c7���#003366$	��Top=�5`   >   6X   �� 5a   
   $��sl/Info.png��6   $��60��6%   $��60��60   $	��Top=�6<   $��0,10,0,0q�6T   �� 5b   
   $��Informacije��6   
���   �$��25(�6:   $��Center=�6H   $	��Top=�6e   $��0,80,0,0q�6}   $��DemiBold"�6�   � 5c   
   $��
0 50 0 180q�6    � RowDefinitions 5d      �� 5e      $��70 �6    �� 5f      $��60 �6    �� 5g      $��5 �6     � ColumnDefinitions 5i      �� 5j      $	��180 �6#   �� 5k      $	��180 �6#   �� 5l      $	��180 �6#   �� 5m      $	��180 �6#   �� 5n      $	��180 �6#   .+�5p      �� -   5        $ 	buttonPos��5p   V   $��1��6   $��1��6%   $	��160��6J   $��Posuđene knjige��6j   $��
0, 0, 0, 0q�6�   $��Center=�6�   $��Center=�6�    "  MaterialDesignFlatDarkBgButton#��[  5q      
�������
�������$��1q�6x   �� 5r      -   5        $ 	buttonVra��5r   V   $��2��6   $��1��6%   $	��160��6J   $��Vraćene knjige��6j   $��
0, 0, 0, 0q�6�   $��Center=�6�   $��Center=�6�   #��[  5s      
�������
�������$��1q�6x   �� 5t      -   5        $ 	buttonOsv��5t   V   $��3��6   $��1��6%   $	��160��6J   $��Sve informacije��6j   $��
0, 0, 0, 0q�6�   $��Center=�6�   $��Center=�6�   #��[  5u      
�������
�������$��1q�6x   5v        5w   
   -   5          Name$ 
gridKnjige��5w      $	��300��6'   $	��850��64   $��	0,110,0,0q�6@      
IsReadOnly . 6e   � 5x   
   $��	0 430 0 0q�6    5y      �� 5z      $��70 �6    �� 5{      $��60 �6    �� 5|      $��5 �6     5~      �� 5      $��90 �6#   �� 5�      $	��180 �6#   �� 5�      $	��180 �6#   �� 5�      $	��180 �6#   �� 5�      $	��180 �6#   �� 5�      $��90 �6#   .+�5�      �� -   5         ��Name$ 
txtBrojKnj��5�   3   $��1��6   $��1��6#   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Ukupan broj knjiga��6G    % !MaterialDesignFloatingHintTextBox#��[ 5�      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��18(�6�   �� 5�      -   5        $ txtBrojacPos��5�   3   $��1��6   $��2��6#   $ Broj posuđenih knjiga��6I   #��[ 5�      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��18(�6�   �� 5�      -	   5        $ 	txtBrClan��5�   3   $��1��6   $��3��6#   $ Ukupan broj članova��6F   #��[ 5�      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��18(�6�   �� 5�      -
   5        $ txtNaj��5�   3   $��1��6   $��4��6#   $ Najaktivniji član��6C   #��[ 5�      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��18(�6�   5�      5�      5�      