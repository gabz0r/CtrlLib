   M S B A M L   `   `   `  ����B  >CtrlLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:CtrlLib.UserInterface.Controls.Host#CtrlLib.UserInterface.Controls.Host  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� 
TargetType   WindowButtonStyle �� Property �� Value �� 
TargetType ��Name J� SnapsToDevicePixels �� ContentStringFormat �� ContentStringFormat �� Triggers	 P� Property
 P� Value4    .CtrlLib.UserInterface.Controls.Host.CtrlWindow � RowDefinitions � ColumnDefinitions ��Name �� Orientation � Title J� IsHitTestVisible ��Name �� RelativeSource �� Path �Name�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;local1clr-namespace:CtrlLib.UserInterface.Controls.Host  5      %�  &	        '   �    7   7   7   �� 5      "  ��6   .�5   
   ��  � �� 5      �� 5      " ��6"   .R�5	      �� $ Chrome��5
      #��z��5      $��0q�5      #��z��5       . ._�5      �� #��z��5   !   #��z��5   !   # z 5   !   #��z��5   !   #��z��5   !   ��. # z 5   !   #��z��5   !   5      5      5      �� 5   
    � ��
 ���� 6'   �� 5   
    � ��$ Webdings)�6'   �� 5   
    � ��$ 17(�6%   �� 5   
    � ��
 �����6'   �� 5    
    � ��$ 0 2 10 0q�6#    5!   
   P� 5"      	 �@J�IsMouseOver
 . . �5#      ��  � ��
 �����6/   5$      5&      �� 5)      "    6   .�5*   
   ��  �@�WindowStyle$
 None=�6(   �� 5+   
    �@�
ResizeMode$ NoResize=�6'   �� 5,   
    � ��
 �����6'   �� 5-   
    � ��$ 1q�6,   �� 5.   
    � �� �#2c3e506(   �� 5/   
    � �� 50      �� 51      "   6"   .R�52      �� #��z��6   #��z��53      
�������._�55      � .+�56      �  57   "   �� 58   &   $��40 �64   �� 59   &   $��* �64   �� 5:   &   $��25 �64    5<   "   �� 5=   &   �� 5>   &   $
��Auto �67   .+�5@   "   �� $ moveRectangle��6,   ���#2c3e50$��0��5A   ,   $��0��69   �� 5C   "   $��0��6-   $��0��6:   $ 
Horizontal=�6J   $��Center=�6c   .+�5D   &   �� #��z 60   $��18(�6O   $
��Bold"�6]   $��5 0 0 0q�6o   
������� .  6�   5E   #   �� 5G   "   $��0��6-   $��1��6:   $ 
Horizontal=�6J   ���#2c3e50.+�5H   &   �� $ minimizeButton��6-   8��  $��0��5I   -   �� 5J   &   $ restoreButton��6-   8�� $��1��5K   -   �� 5L   &   $ closeButton��6-   8�� $��r��5M   -   5N   #   � 5P   "   #��z��6'   $��1��5Q   ,   $��2��69   $��5 5 5 5q�6M   .+�5R   &   �� .u�5S   *   �� 5T   '   5U   #   ]� 5W   "   $��2��6,   $��2��69   $��Stretch=�6M   ���#2c3e50.+�5X   &   �� $ 
Horizontal=�61   $��Right=�6J   $��0 0 15 0q�6f   .+�5Y   *   �� $��Angemeldeter Benutzer:��64   $��Center=�6R   $��12(�6m   $
��Bold"�6{   $��0 0 5 0q�6�   
�������6�   �� 5Z   *   $��Center=�6�   $��12(�6�   
���������64   ��  �� *TemplatedParent+$ CtrlUser�6�   5[   '   5\   #   5^      � 5`      $ 
resizeGrid��6#   .+�5a   "   �� $	 top��5e   -   
������ $	��Top=�5c   -   $��5��5d   -   $��5 0 5 0q�5f   -   ��5a   -   Z� 5f   -   �� 5g   "   $ bottom��5i   -   
������ $��5��5j   -   $��Bottom=�5k   -   $��5 0 5 0q�5l   -   ��5g   -   Z� 5l   -   �� 5m   "   $
 left��5r   -   
������ $
��Left=�5o   -   $��0 5 0 5q�5p   -   $��5��5q   -   ��5m   -   Z� 5r   -   �� 5s   "   $ right��5x   -   
������ $��0 5 0 5q�5u   -   $��5��5v   -   $��Right=�5w   -   ��5s   -   Z� 5x   -   �� 5y   "   $ 
bottomLeft��5   -   
������ $
��Left=�5{   -   $��Bottom=�5|   -   $��5��5}   -   $��5��5~   -   ��5y   -   Z� 5   -   �� 5�   "   $ bottomRight��5�   -   
������ $��Bottom=�5�   -   $��5��5�   -   $��5��5�   -   $��Right=�5�   -   ��5�   -   Z� 5�   -   �� 5�   "   $ topRight��5�   -   
������ $��Right=�5�   -   $��5��5�   -   $��5��5�   -   $	��Top=�5�   -   ��5�   -   Z� 5�   -   �� 5�   "   $ topLeft��5�   -   
������ $
��Left=�5�   -   $��6��5�   -   $	��Top=�5�   -   $��5��5�   -   ��5�   -   Z� 5�   -   5�      5�      5�      5�      5�      5�      5�      