   M S B A M L   `   `   `  ����F  BViewChanger, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ViewChanger.ViewsViewChanger.Views  5      ?$clr-namespace:ViewChanger.ViewModelsViewChanger.ViewModels  5           ViewChanger.Views.HomeView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ViewChanger.Views     5      3vm$clr-namespace:ViewChanger.ViewModels     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5        � DataContext  5      *   $ViewChanger.ViewModels.HomeViewModel  5   
    � 	Resources 5         ListViewStyle �� 
TargetType �� Property �� Value��%T   &	        �� 5   
   " ��6&   .�5      ��  � ��$
 Left=�6;   5      5      .��5      � 
���  �� � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!    � RowDefinitions 5!   
   �� 5"      $
��310* �6   6,   �� 5#      $
��139* �6   6,   .+�5'   
   �  5(      �� 5)      $��7* �6#   60   �� 5*      $	��69* �6#   61   �� 5+      $��4* �6#   60    5/      �� 50      $	��15* �6    6/   �� 51      $
��270* �6    60   �� 53      $	��26* �6    6/   .+�58      �� $��1��6   $��1��6$   $��7.8,8.8,0,8.8q�64   $
��Left=�6�   $
��Left=�6�   $	��330��6  ��6K   �� *	Players+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *SelectedPlayer+$ PropertyChanged=�	 �� View	 59      �� 5:      .P�5;      �� $��Player Name��6�   
 �� Width$	
 100��6�    �� HeaderContainerStyle 6)   ��  �� Source# [  $ PropertyChanged=� �� DisplayMemberBinding 6�   �� *Name+$ PropertyChanged=��� 5<      $��	Games Won��6�   $	
 100��6�    6)   �� # [  $ PropertyChanged=� 6�   �� *Wins+$ PropertyChanged=��� 5=      $��
Games Lost��6�   $	
 100��6�    6)   �� # [  $ PropertyChanged=� 6�   �� *Loses+$ PropertyChanged=�5?      5B      5F      � 5G   
   $��0��6   $��1��6    5H      �� 5I      $	��28* �6    6/   �� 5J      $��3* �6    6.   .+�5O      �� $��0��6   $��0��6%   ��66   �� *SelectedPImage+6Z   � 5P      $��1��6   $��0��6     5Q      �� 5R      6)   �� 5S      6)   .+�5V      �� $��0��6   $��80��6)   ��64   �� *
NextPlayer+.��6S   Left6Y   �� 5W      $��1��6   $��80��6)   ��64   �� *PreviousPlayer+.��6W   Right6^   5Z      5\      � 5a   
   $��1��6    5c      �� 5d      6%   �� 5e      6%   .+�5i      �� $��50��6   $��90��6!   ��6,   �� *goToSignUpView+.��6O   
New Player6\   �� 5j      $��1��6   $��50��6%   $��90��61   {�6<   �� *EnablePlayButton+$ PropertyChanged=���6�   �� *DeletePlayer+$ PropertyChanged=�.��6�   Delete Player6�   5l      � 5n   
   $��1��6   $��1��6    5p      �� 5q      6%   �� 5r      6%   .+�5v      �� $��50��6   $��90��6!   {�6,   �� *EnablePlayButton+$ PropertyChanged=���6x   �� *goToGameView+.��6�   Play6�   �� 5w      $��1��6   $��50��6%   $��90��61    �� IsCancel . .��6N   Cancel6V   5y      5~      5      