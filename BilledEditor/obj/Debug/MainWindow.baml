   M S B A M L   `   `   `  ����G  CBilledEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BilledEditorBilledEditor  5   	       BilledEditor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BilledEditor     5   	     � Title$  Urmager Billed Editor��5   	   $	��825��6'   $��757.5��64    � WindowStartupLocation$ CenterScreen=�6B   .��5	      � $��0,0,0,0q�6   .+�5
   
   �� -   5         ��Name$ btn_save��5
      $��Gem Færdig billede��6#   $
��Left=�6@   $��50��6[   $��594,728,0,0q�6g   $	��Top=�6|   $	��132��6�   #��� ��6�   �� 5   
   -   5        $ btn_load��5      $��Hent nyt billede��6#   $
��Left=�6>   $��50��6Y   $��594,618,0,0q�6e   $	��Top=�6z   $	��132��6�   #��� ��6�   �� 5   
   -   5        $ 	btn_opret��5      $��Opret Mærke��6$   $
��Left=�6:   $��50��6U   $��594,563,0,0q�6a   $	��Top=�6v   $	��132��6�   #��� ��6�   �� 5   
   -   5        $ btn_lock��5      $��
Gem Mærke��6#   $
��Left=�67   $��50��6R   $��
594,75,0,0q�6^   $	��Top=�6r   $	��132��6�   $y�Visible=�6�   #��� ��6�   �� 5   
   -   5        $ btn_PlaceButton��5      $��Indsæt Mærke��6*   $
��Left=�6A   $��50��6\   $��
594,75,0,0q�6h   $	��Top=�6|   $	��132��6�   $y�Visible=�6�   #��� ��6�   �� 5   
   -   5        $ btn_tilbage��5      $��Til Start Menu��6&   $
��Left=�6?   $��50��6Z   $��594,130,0,0q�6f   $	��Top=�6{   $	��132��6�   $y�Visible=�6�   #��� ��6�   �� 5   
   -   5        $ btn_annulere��5      $��Annuller��6(   $
��Left=�6;   $��50��6V   $��594,130,0,0q�6b   $	��Top=�6w   $	��132��6�   $y�Visible=�6�   #��� ��6�   �� 5   
   #��� ��6   $��10,10,164,10q�6`   ._�5      �� -   5        $��canvas��5      .+�5      � -	   5        $��
ImageRamme��5      .+�5      �� -
   5        $��imageviewer��5      $
��Fill=�6/   $��10,10,10,10q�6>   5      5      5      �� 5   
   -   5         ��Name$ txt_nr��5      $��16(�6"   $��Center=�60   $��Center=�6T   $
��Left=�6v   $��34��6�   $��
584,32,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��150��6�   $y�Visible=�6�   #��� ��6  �� 5   
   -   5        $ btn_hentXml��5      $��Rediger billede��6&   $
��Left=�6@   $��50��6[   $��594,673,0,0q�6g   $	��Top=�6|   $	��132��6�   #��� ��6�   5      5      