   M S B A M L   `   `   `  ����I  EContestationUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ContestationUIContestationUI  5   	        ContestationUI.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ContestationUI     5   	   -   5          � Title$  
MainWindow��5   	   $	��315��6   $	��410��6(    � 
ResizeMode$ NoResize=�5	       � WindowStyle$
 None=�6   
������ .��5
      � .+�5   
   �� $	��315��6   $	��410��5      
������� �� CornerRadius$ 6��5       J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 15Q�6#      	Direction$	 -90Q�5         RenderingBias$ Quality=�5         ShadowDepth$ 2Q�5      	   Color$
	 Gray��5      ._�5      �� 
 �� Orientation$
 Vertical=�6   $��20q�5      .+�5      �� $��Login��6   $��25(�5      $��Center=�5      $	��Top=�5      $
��Bold"�5       �� Padding$ 10q�5      � 5      $��Center=�6    � RowDefinitions 5       �� 5!      $��* �6(   �� 5"      $��* �6(   �� 5#      $��* �6(   �� 5$      $��* �6(   �� 5%      $��* �6(   �� 5&      $��* �6(   �� 5'      $��* �6(   .+�5*      �� $��	User Name��6    $��0��5+      $
��0,15q�5,      $
��Left=�5-      �� 5/      -   5         ��Name$ txtUserName��5/      $��1��63   $	��0,5q�50      $	��255��51      $��0,0,0,1q�52      $
��Left=�53      �� 55      $��Password��6    $��2��56      $
��0,15q�57      $
��Left=�58      G� 5:      -   5         G�Name$ txtPassword��5;      $��3��5:   "   $	��0,5q�5<      $	��255��5=      $��0,0,0,1q�5>      $
��Left=�5?      5@      �� 5A      -   5         ��Name$ LoginBtn��5A      $��Login��5B       � Cursor$
 Hand��5C      
�������
���   �$
��0,25q�5F      $��35��5G      $	��250��5H      ��5J      �� 5K       �� 
TargetType" ��6    .�5L      ��  �� Property � �� �� Value 5M   "   �� 5N   &    �� 
TargetType" ��66   .R�5O   *   ��  ��Name$ LoginBorder��61   #��z��6F   $ 16��5P   -   ._�5Q   .   �� $��Center=�6?   $��Center=�5R   ;   5S   +    �� Triggers 5T   *   P� 5U   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5V   2   ��  �� 
TargetName$ LoginBorder��6a    � ��
 ������� 5W   2   $ LoginBorder��6h    � ��
 �   �5X   /   5Z   '   5\      5]      5_      5`      5a      5b      5c      