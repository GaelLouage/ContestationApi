   M S B A M L   `   `   `  ����I  EContestationUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ContestationUIContestationUI  5   	       ContestationUI.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ContestationUI     5   	   -   5          � Title$  
MainWindow��5   	   $
��1000��6   $
��1200��6*    � 
ResizeMode$ NoResize=�5	       � WindowStyle$
 None=�6   .��5
      � -   5         � RowDefinitions 5      �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0��6;   $��6��6K   .+�5!      �� -   5         ��Name$ MenuBtn��5!      $
��Menu��5"       � Cursor$
 Hand��5#      $��1��5$      
�������
���   �$��1��5'      $��35��5(      $	��400��5)      ��5*      �� 5+       �� 
TargetType" ��6   .�5,      �� 	 �� Property	 � ��
 �� Value
 5-      �� 5.   "    �� 
TargetType" ��62   .R�5/   &   ��  ��Name$ LoginBorder��6-   #��z��6B    �� CornerRadius$ 0��50      ._�51   *   �� $��Center=�6;   $��Center=�52      53   '    �� Triggers 54   &   P� 55   *    P� Property �@J�IsMouseOver P� Value$
 True��6I   . �56   .   ��  �� 
TargetName$ LoginBorder��6]   	 � ��

 ������� 57   .   $ LoginBorder��6d   	 � ��

 �   �58   +   5:   #   5<      5=      5?      �� 5A      -   5        $ OpposersBtn��5A      $��Contestations��5B      $
 Hand��5C      $��1��5D      
�������
���   �$��2��5G      $��35��5H      $	��400��5I      ��5K      �� 5L      " ��6   .�5M      �� 	 � ��
 5N      �� 5O   "   " ��62   .R�5P   &   �� $ LoginBorder��6-   #��z��6B   $ 0��5Q      ._�5R   *   �� $��Center=�6;   $��Center=�5S      5T   '    5U   &   P� 5V   *    �@J�IsMouseOver$
 True��6I   . �5W   .   �� $ LoginBorder��6]   	 � ��

 ������� 5X   .   $ LoginBorder��6d   	 � ��

 �   �5Y   +   5[   #   5]      5^      5`      �� 5b      -   5        $ StatisticsBtn��5b      $��
Statistics��5c      $
 Hand��5d      $��1��5e      
�������
���   �$��2��5h      $��35��5i      $	��400��5j      ��5l      �� 5m      " ��6   .�5n      �� 	 � ��
 5o      �� 5p   "   " ��62   .R�5q   &   �� $ LoginBorder��6-   #��z��6B   $ 0��5r      ._�5s   *   �� $��Center=�6;   $��Center=�5t      5u   '    5v   &   P� 5w   *    �@J�IsMouseOver$
 True��6I   . �5x   .   �� $ LoginBorder��6]   	 � ��

 ������� 5y   .   $ LoginBorder��6d   	 � ��

 �   �5z   +   5|   #   5~      5      5�      5�      �� 5�   
   -   5         ��Name$ MainContent��5�      $��2��5�      $��5��6   $��6��5�      5�      5�      