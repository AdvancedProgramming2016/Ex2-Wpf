   M S B A M L   `   `   `  ����C  ?MazeMenu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MazeMenuMazeMenu  5   	       MazeMenu.SettingsMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:MazeMenu     5   	     � Title$  SettingsMenu��5   	   $	��300��6   $	��300��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ ipAddressBlock��5
      $
��Left=�6,   $��	22,27,0,0q�6G   $
��Wrap=�6Z   $��IP address:��6n   $	��Top=�6�   �� 5   
   -   5         ��Name$ ipAddressBox��5      $
��Left=�6(   $��23��6C   $��
109,26,0,0q�6O    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $ 	PortBlock��5      $
��Left=�6'   $��	22,67,0,0q�6B   $
��Wrap=�6U   $��Port address:��6i   $	��Top=�6~    J� RenderTransformOrigin$ -0.082,-0.438&�6�   �� 5   
   -   5        $ portBox��5      $
��Left=�6<   $��23��6W   $��
109,60,0,0q�6c   $
 Wrap=�6w   $	��Top=�6�   $	��120��6�   ��6#   �� *	VM_Port+6�   �� 5   
   -   5        $ mazeRowsBlock��5      $
��Left=�6+   $
��Wrap=�6F   $��
Maze rows:��6Z   $	��Top=�6l   $��	22,98,0,0q�6�   �� 5   
   -   5        $ mazeBox��5      $
��Left=�6#   $��23��6>   $��
109,98,0,0q�6J   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ 	algorithm��5      $
��Left=�6'   $��
22,179,0,0q�6B   $
��Wrap=�6V   $��
Algorithm:��6j   $	��Top=�6|   �� 5   
   -   5         ��Name$ algorithmComboBox��5   B   $
��Left=�6]   $��109,173,0,0q�6x   $	��Top=�6�   $	��120��6�    �� SelectedIndex 6   ��  �� Path$ VM_SelectedAlgo�.@�5      �� $	��Bfs��6   $
��Left=�6)   $	��118��6D   �� 5      $	��Dfs��6   $
��Left=�6)   $	��118��6D   5      �� 5   
   -	   5        $ mazeColsBox��5      $
��Left=�6'   $��23��6B   $��109,137,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -
   5        $ mazeColsBlock��5      $
��Left=�6+   $
��Wrap=�6F   $��Maze Coloms:��6Z   $	��Top=�6n   $��
22,140,0,0q�6�   �� 5   
   -   5         ��Name$ okButton��5      $��Ok��6#   $
��Left=�60   $��109,216,0,0q�6K   $	��Top=�6`   $��75��6x   5!      5"      