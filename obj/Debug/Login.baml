   M S B A M L   `   `   `  ����A  =Login2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Login2Login2  5   	       Login2.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Login2     5   	   b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � Title$  Login��5	   	   $	��500��6   $	��350��6$    � 
ResizeMode$ NoResize=�5
   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $��Segoe UI Emoji)�5   	   .��5      � .+�5   
   �� $	��250��6   $	��Top=�6!   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ #A5CC82��6#   � 5      $ #bdc3c7��6#    � Offset$	 0.9Q�63   5      5      �� 5   
   $	��280��6   $	��240��6    $��Bottom=�6-   $
��0,80q�6H    �� RadiusY$ 10��6V   	 �� RadiusX$	 10��6c   
�������
 J� Effect
 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$ 0Q�63      RenderingBias$ Quality=�6A      ShadowDepth$ 1Q�6Y      Color$ 	#FFBBBBBB��6i   5      � 5   
   $��Bottom=�6   $��35,80q�6*   $	��240��69   .+�5      �� $��PRIJAVA��6   $��Center=�6&   $	��Top=�6C   $��5q�6[   
�������$��18(�6x   �� 5       $��Center=�6   $��15q�64   .+�5!      �� -   5         ��Name$ txtUsername��5!      $
��0,10q�6/   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Korisnicko ime��6=    %  !MaterialDesignFloatingHintTextBox#��[  6m   $��Champagne & Limousines)�6�   $��18(�6�   G� 5"      -   5         G�Name$ passLozinka��5"      $
��0,10q�63   $ Lozinka��6A    ) %MaterialDesignFloatingHintPasswordBox#��[ 6j   $��Champagne & Limousines)�6�   $��18(�6�   5#      5$      �� 5%   
   -   5         ��Name$ ButtonLogin��5%      $	��150��6&   $��Center=�62   $��Bottom=�6O   $
��0,65q�6j   $��PRIJAVA��6x   ���#003366
�������6�   �� 5&   
   -   5        $ buttonRegistracija��5&      $��Registracija��6-   $��Center=�6D   $��Bottom=�6a   $��30q�6|     MaterialDesignFlatButton#��[ 6�   6�   �� 5'   
   $��sl/biblioteka.png��6   $	��100��6+   $	��100��67   $	��Top=�6D   $��65q�6\   �� 5(   
   $��
BIBLIOTEKA��6   $��Center=�6%   $	��Top=�6B   $��40q�6Z   ���#003366$��30(�6{   $��	ExtraBold"�6�   �� 5)   
   .+�5*      �� -   5        $ buttonZatvori��5*      $	��✖��6,   $��0q�68   $��29��6D   $��30��6P   $��Right=�6\   ���#003366���#bdc3c7���#0033666�   5+      5,      5.      