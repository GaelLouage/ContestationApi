   M S B A M L   `   `   `  ����I  EContestationUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ContestationUI.UserControlsContestationUI.UserControls  5      1    +ContestationUI.UserControls.MenuUserControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ContestationUI.UserControls     5      .��5
   
   � -   5          � ColumnDefinitions  5      �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    .+�5      �� -   5         ��Name$ txtUserName��5      $��0��6-   $��0��6:   $��4��6J   $��Center=�5      $��Center=�5      $��24(�5      $
��Bold"�5      �� 5      -   5         ��Name$ iconContestation��5      $��1��5      $��2��5      $��Center=�5      $��Center=�5      $��3��5       $	��250��5!      $	��250��5"      �� 5&      -   5         ��Name$ ExitBtn��5&      $��3��5'      $��2��5(      $��Center=�5)      $��Center=�5*      $��3��5+      $
��Exit��5,       � Cursor$
 Hand��5-      
�������
���   �$
��0,25q�50      $��35��51      $	��150��52      ��54      �� 55       �� 
TargetType" ��6   .�56      ��  �� Property � �� �� Value 57      �� 58   "   	 �� 
TargetType"	 ��62   .R�59   &   �� 
 ��Name$
 LoginBorder��6-   #��z��6B    �� CornerRadius$ 16��5:      ._�5;   *   �� $��Center=�6;   $��Center=�5<   +   5=   '    �� Triggers 5>   &   P� 5?   *    P� Property �@J�IsMouseOver P� Value$
 True��6I   . �5@   .   ��  �� 
TargetName$ LoginBorder��6]    � ��
 ������� 5A   .   $ LoginBorder��6d    � ��
 �   �5B   +   5D   #   5F      5G      5I      5J      5L      