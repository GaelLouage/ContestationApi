   M S B A M L   `   `   `  ����I  EContestationUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:ContestationUI.UserControlsContestationUI.UserControls  5      0    *ContestationUI.UserControls.OpposerControl   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:ContestationUI.UserControls     5      .��5	      � -   5          � ColumnDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Search:��6   $��0��5      $��3��6!    �� Padding$	 0,5q�5      $��10q�5      $��Right=�5      �� 5   
   -   5         ��Name$ txtUserName��5      $��0��6'   $��4��64   $��4��6D   $	��0,5q�5       $	��300��5!      $��10q�5"      $��0,0,0,1q�5#      $��center=�5$      6#   �� 5%   
   -   5         ��Name$ OpposersListView��5%      $��
12,10,8,10q�6-   $��6��6A   $��1��6U   $��0��6b   $��2��6r    �� View 5&      �� 5'      .P�5)      �� $��Decision��6%    �� Width$	 100��67    �� CellTemplate 5*      �� 5+      .R�5,   "   ��  �� Padding$ 4q�6)   	 �� CornerRadius$	 2��65   ��5-   &   �� 5.   *   
 �� 
TargetType"
 ��60    �� Triggers 5/   .   �� 50   2    �� Binding 6>   �� *DecisionType+ �� Value ACCEPTED6_   .a�51   6   ��  �� Property � �� �� Value
 ����6S   52   3   �� 53   2    6>   �� *DecisionType+ REJECTED6_   .a�54   6   ��  � ��
 �����6S   55   3   �� 56   2    6>   �� *DecisionType+ NONE6_   .a�57   6   ��  � ��
 �����6S   58   3   5:   +   ._�5<   &   �� $��Center=�5=   (   $��Center=�5>   (   $��SemiBold"�5?   (   ��5<   0   �� *DecisionType+5?   (   5@   #   5A      5C      �� 5F      $��Fine #��6%   $	 100��6a    �� DisplayMemberBinding 65   �� *
FineNumber+6a   �� 5G      $��	Full Name��6%   $	 150��6b    68   �� *
FullName+6b   �� 5H      $��Email��6%   $	 150��6[    64   �� *Email+6[   �� 5I      $��Phone��6%   $	 100��6[    64   �� *Phone+6[   �� 5J      $
��City��6%   $	 100��6Y    63   �� *City+6Y   �� 5K      $��
Issue Date��6%   $	 100��6h    69   �� *FineIssueDate+6h   �� 5L      $��Reason��6%   $	 200��6d    65   �� *ReasonForFine+6d   5M      5O      �� 5P   
   $��Contestation��6   $��4��6)   $��10q�66   $��3��6B   .��5Q      �   5R      �� 5S      $��* �6'   �� 5T      $��* �6'   �� 5U      $��* �6'    5W      �� 5X      $��* �6$   �� 5Y      $��* �6$   �� 5Z      $��* �6$   �� 5[      $��* �6$   �� 5\      $
��auto �6$   .+�5^      �� $��Fine #: ��6   $��0��6,   �� 5_      -   5         ��Name$ txtFineNumber��5_      $	��...��63   $��1��6>   �� 5`      $��ReasonForContestation: ��6   $��0��6;   $��1��6K   �� 5a      -   5        $ txtReasonForContestation��5a      $	��...��6>   $��1��6J   $��1��6Z   $��3��6g   �� 5b      $��Notes: ��6   $��0��6+   $��2��6;   �� 5c      -   5        $ txtNotes��5c      $��2��6,   $��1��69   $��3��6I   $	��0,5q�5d      $	��300��5e      $	��Top=�5f      $
��Left=�5g      $��0,0,0,1q�5h      �� 5k      -   5         ��Name$ cmbDecisionType��5k      $��0,20,0,0q�65   $��3��6H   $��0��6U   $��3��6e   $��Bottom=�6y   �� 5m      -   5         ��Name$ BtnDecision��5m      $��Center=�5n      $��Center=�5o      $��Submit��5p       � Cursor$
 Hand��5q      $��4��5r      $��0��5s      $��3��6+   
�������
���   �$
��0,25q�5v      $��35��5w      $	��150��5x      ��5y      �� 5z      "
 ��6    .�5{      ��  � �� 5|   "   �� 5}   &    �� 
TargetType" ��66   .R�5~   *   ��  ��Name$ LoginBorder��61   #��z��6F   $	 16��5      ._�5�   .   �� $��Center=�6?   $��Center=�5�   )   5�   +    �� Triggers 5�   *   P� 5�   .    P� Property �@J�IsMouseOver P� Value$
 True��6M   . �5�   2   ��  �� 
TargetName$ LoginBorder��6a    � ��
 ������� 5�   2   $ LoginBorder��6h    � ��
 �   �5�   /   5�   '   5�      5�      5�      5�      5�      �� 5�   
   -	   5        $ 	txtAmount��5�      $	��...��6'   $��4��62   $��6��6?   $��Center=�6O   $��0,0,0,0q�6l   $
��Bold"�6}   �� 5�   
   -
   5        $ BtnDownload��5�      $��3��5�      $��4��5�      $��Center=�5�      $��Center=�5�      $��Download��5�      $
 Hand��5�      
�������
���   �$
��0,25q�5�      $��35��5�      $	��150��5�      ��5�      �� 5�      "
 ��6   .�5�      ��  � �� 5�      �� 5�      " ��6.   .R�5�   "   �� $ LoginBorder��6)   #��z��6>   $	 16��5�      ._�5�   &   �� $��Center=�67   $��Center=�5�   )   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   �� $ LoginBorder��6Y    � ��
 ������� 5�   *   $ LoginBorder��6`    � ��
 �   �5�   '   5�      5�      5�      5�      �� 5�   
   -   5        $ BtnExit��5�      $��3��5�      $��5��5�      $��Center=�5�      $��Center=�5�      $
��Exit��5�      $
 Hand��5�      
�������
���   �$
��0,25q�5�      $��35��5�      $	��150��5�      ��5�      �� 5�      "
 ��6   .�5�      ��  � �� 5�      �� 5�      " ��6.   .R�5�   "   �� $ LoginBorder��6)   #��z��6>   $	 16��5�      ._�5�   &   �� $��Center=�67   $��Center=�5�   )   5�   #    5�   "   P� 5�   &    �@J�IsMouseOver$
 True��6E   . �5�   *   �� $ LoginBorder��6Y    � ��
 ������� 5�   *   $ LoginBorder��6`    � ��
 �   �5�   '   5�      5�      5�      5�      (  "System.Windows.Controls.WebBrowser  5�   
   -   5          Name$ 
PdfBrowser��5�      $y�Hidden=�6)   $��1��6=   $��2��6J   5�      5�      