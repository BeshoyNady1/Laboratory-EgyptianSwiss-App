TYPE=VIEW
query=select `swiss_db`.`h_payrequest_report_db`.`id_num` AS `id_num`,`swiss_db`.`h_payrequest_report_db`.`my_name` AS `my_name`,`swiss_db`.`h_payrequest_report_db`.`date` AS `date`,`swiss_db`.`h_payrequest_report_db`.`who_want` AS `who_want`,`swiss_db`.`h_payrequest_report_db`.`depart` AS `depart`,`swiss_db`.`h_payrequest_report_db`.`storag_manage` AS `storag_manage`,`swiss_db`.`h_payrequest_report_db`.`milling_manage` AS `milling_manage` from `swiss_db`.`h_payrequest_report_db` where `swiss_db`.`h_payrequest_report_db`.`milling_manage` is null union select `swiss_db`.`h_payrequest_normal_report_db`.`id_num` AS `id_num`,`swiss_db`.`h_payrequest_normal_report_db`.`my_name` AS `my_name`,`swiss_db`.`h_payrequest_normal_report_db`.`date` AS `date`,`swiss_db`.`h_payrequest_normal_report_db`.`who_want` AS `who_want`,`swiss_db`.`h_payrequest_normal_report_db`.`depart` AS `depart`,`swiss_db`.`h_payrequest_normal_report_db`.`storag_manage` AS `storag_manage`,`swiss_db`.`h_payrequest_normal_report_db`.`milling_manage` AS `milling_manage` from `swiss_db`.`h_payrequest_normal_report_db` where `swiss_db`.`h_payrequest_normal_report_db`.`milling_manage` is null order by `id_num` desc
md5=6fd496ce10505b864744845341d66f86
updatable=0
algorithm=0
definer_user=root
definer_host=localhost
suid=2
with_check_option=0
timestamp=2021-12-13 10:18:55
create-version=2
source=SELECT `id_num`,`my_name`,`date`,`who_want`,`depart`,`storag_manage`,`milling_manage` FROM `h_payrequest_report_db` WHERE `milling_manage` IS NULL \nUNION\nSELECT `id_num`,`my_name`,`date`,`who_want`,`depart`,`storag_manage`,`milling_manage` FROM h_payrequest_normal_report_db WHERE `milling_manage` IS NULL\nORDER BY `id_num` DESC
client_cs_name=utf8mb4
connection_cl_name=utf8mb4_unicode_ci
view_body_utf8=select `swiss_db`.`h_payrequest_report_db`.`id_num` AS `id_num`,`swiss_db`.`h_payrequest_report_db`.`my_name` AS `my_name`,`swiss_db`.`h_payrequest_report_db`.`date` AS `date`,`swiss_db`.`h_payrequest_report_db`.`who_want` AS `who_want`,`swiss_db`.`h_payrequest_report_db`.`depart` AS `depart`,`swiss_db`.`h_payrequest_report_db`.`storag_manage` AS `storag_manage`,`swiss_db`.`h_payrequest_report_db`.`milling_manage` AS `milling_manage` from `swiss_db`.`h_payrequest_report_db` where `swiss_db`.`h_payrequest_report_db`.`milling_manage` is null union select `swiss_db`.`h_payrequest_normal_report_db`.`id_num` AS `id_num`,`swiss_db`.`h_payrequest_normal_report_db`.`my_name` AS `my_name`,`swiss_db`.`h_payrequest_normal_report_db`.`date` AS `date`,`swiss_db`.`h_payrequest_normal_report_db`.`who_want` AS `who_want`,`swiss_db`.`h_payrequest_normal_report_db`.`depart` AS `depart`,`swiss_db`.`h_payrequest_normal_report_db`.`storag_manage` AS `storag_manage`,`swiss_db`.`h_payrequest_normal_report_db`.`milling_manage` AS `milling_manage` from `swiss_db`.`h_payrequest_normal_report_db` where `swiss_db`.`h_payrequest_normal_report_db`.`milling_manage` is null order by `id_num` desc
mariadb-version=100419
