   M S B A M L   `   `   `  ����A  =Login2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Login2Login2  5   	       Login2.PretragaClanova   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	    localclr-namespace:Login2  5   	   -   5          � Title$  PretragaClanova��5	   	   $	��720��6!   $	��800��6.    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	    � 	Resources 5       �� MergedDictionaries �� Source&   System.Windows.Controls.DataGrid �� 
TargetType �� Property	 �� Value)  #System.Windows.Controls.DataGridRow
 �� Triggers P� Property P� Value*  $System.Windows.Controls.DataGridCell �� 
TargetType �� Padding�� 5   
    5      �� 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml?�6%   �� 5      $z tpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.DeepPurple.xaml?�6%   �� 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml?�6%   %4  '        �� 5   
   "  6   .�5      ��  � ��	 �#DDDDDD6,   �� 5        �@ HorizontalGridLinesBrush	 �#DDDDDD69   �� 5       �@ VerticalGridLinesBrush	 �#DDDDDD67   �� 5       �@ RowStyle	 5       �� 5!      "  6   
 5"      P� 5$       �@J�IsMouseOver . . �5%   "   ��  � ��
	 �����6?   5&      5(      5*      �� 5+       �@ 	CellStyle	 5,      �� 5-      "  6   
 5.      P� 50       �@ 
IsSelected . . �51   "   ��  � ��	 �	#ff66ccff6?   �� 52   "    � ��
	 ���� 6@   �� 53   "    � ��	 �#0033666?   54      P� 55       �@J�	IsFocused . . �56   "   ��  � ��	 �	#ff66ccff6?   �� 57   "    � ��	 �#0033666@   �� 58   "    � ��$	 1q�6D   �� 59   "    � ��	 �#0033666?   5:      .�5=      ��  � ��$	 4,3,4,3q�64   �� 5>       � ��
	 ���� 68   �� 5?       � ��$	 1q�6<   �� 5@       � ��	 5A      �� 5B   "   "  62   .R�5C   &   �� # z��6-   #��z��5D   -   #��z��5E   -   #��z��5F   -   ._�5G   *   �� 5H   '   5I   #   5K      �� 5L       �@�FocusVisualStyle	 5M      �� 5N   "   " ��6(   .�5O   &   ��  � ��
	 ���� 6D   5P   #   5R      5S      5U      5V      5W      .��5Y      � ��5Z   
   �� 5[       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5\      �  � Color$ #4f3f63��6   � 5]      $ #bdc3c7��6    � Offset$	 0.9Q�6/   5^      .+�5`   
   �� $��
20,0,20,20q�6   $	��300��6%   
�������$��Bottom=�6G   $ 
30,20,30,0q�6b    �� CornerRadius$ 10��6w   $	��800��6�   $	��300��6�    J� Effect 5a      3  -System.Windows.Media.Effects.DropShadowEffect  5b         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5d      �� $��0q�6   .+�5f      � $��0 0 0 0q�6   .+�5g      �� $��Ažuriranje i brisanje��6    
���   �$��25(�6P   6`   5i      � 5j       � ColumnDefinitions 5k      �� 5l      $��30 �6+   68   �� 5m      $	��250 �6+   69   �� 5n      $	��140 �6+   69   �� 5o      $	��250 �6+   69   �� 5p      $��30 �6+   68    � RowDefinitions 5r      �� 5s      $
��auto �6(   68   �� 5t      $��10 �6(   66   �� 5u      $
��auto �6(   68   �� 5v      $��10 �6(   66   �� 5w      $
��auto �6(   68   �� 5x      $��10 �6(   66   .+�5z      �� -   5         ��Name$ 	txtClBroj��5z   ;   $��0��6   $��1��6+   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Broj člana��6N    %  !MaterialDesignFloatingHintTextBox#��[  5{      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��16(�6�   �� 5|      -   5        $ txtIme��5|   ;   $��2��6   $��1��6+   $	 Ime��6K   #��[  5}      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��16(�6�   �� 5~      -   5        $ 
txtPrezime��5~   ;   $��4��6   $��1��6+   $ Prezime��6O   #��[  5      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��16(�6�   �� 5�      -   5        $ 	txtAdresa��5�   ;   $��0��6   $��3��6+   $ Adresa��6N   #��[  5�      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��16(�6�   �� 5�      -   5        $ txtEmail��5�   ;   $��2��6   $��3��6+   $ Email��6M   #��[  5�      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��16(�6�   �� 5�      -   5        $ 
txtBrojTel��5�   ;   $��4��6   $��3��6+   $ Broj telefona��6O   #��[  5�      $	��0 5q�6Y   $��Champagne & Limousines)�6f   $��16(�6�   5�      � 5�       5�      �� 5�      $	��150 �6+   �� 5�      $	��200 �6+   �� 5�      $	��200 �6+   �� 5�      $	��150 �6+   .+�5�      �� -   5         ��Name$ buttonAzuriraj��5�   -   $��1��6   $��Ažurirajte podatke��6E   $��20 20q�6b   ���#4f3f636�   �� 5�      -	   5        $ buttonObrisi��5�   -   $��2��6   $��Obrišite podatke��6C   $��20 20q�6^   
��� E��6�   5�      5�      5�      �� 5�   
   $��sl/PretragaClanova.png��6   $��60��60   $��60��6;   $	��Top=�6G   $��0,20,0,0q�6_   � 5�   
    5�      �� 5�      $	��200 �6#   �� 5�      $	��200 �6#   �� 5�      $	��200 �6#   �� 5�      $	��200 �6#   .+�5�      �� -
   5        $ txtPretraga��5�   &   $��1��6   $ 🔍 Broj člana��6U   #��[  5�      $��0,80,0,0q�6Q   $��Champagne & Limousines)�6c   $��16(�5�      $	��Top=�6$   $��Right=�6<   
�������6X   �� 5�      -   5        $ buttonOsvjezi��5�   %   $��2��6   $��Osvježi��6<   $��20, 90, 0, 0q�6j   $	��Top=�6�   $
��Left=�6�     MaterialDesignFlatButton#��[ 5�      ���#DDDD
�������$��1q�6r   5�        5�   
   -   5          Name$ 
gridKnjige��5�      $	��250��6'   $	��760��64   $��	0,0,0,200q�6@      
IsReadOnly . 6e   �� 5�   
   -   5        $ buttonZatvori��5�      $	��✖��6(   $��0q�64   $��29��6@   $��30��6L   $��Right=�6X   ���#003366���#bdc3c7���#003366$	��Top=�5�   X   6r   5�      5�      