TYPE=VIEW
query=select `chackreport_notification`.`id_num` AS `id_num`,`chackreport_notification`.`date` AS `date`,`chackreport_notification`.`my_name` AS `my_name`,`chackreport_notification`.`recipient` AS `recipient`,`chackreport_notification`.`recipient_name` AS `recipient_name` from `swiss_db`.`chackreport_notification` union select `addreturn_notification`.`id_num` AS `id_num`,`addreturn_notification`.`date` AS `date`,`addreturn_notification`.`my_name` AS `my_name`,`addreturn_notification`.`recipient` AS `recipient`,`addreturn_notification`.`recipient_name` AS `recipient_name` from `swiss_db`.`addreturn_notification` union select `paypart_notification`.`id_num` AS `id_num`,`paypart_notification`.`date` AS `date`,`paypart_notification`.`my_name` AS `my_name`,`paypart_notification`.`recipient` AS `recipient`,`paypart_notification`.`recipient_name` AS `recipient_name` from `swiss_db`.`paypart_notification` union select `payrequest_notifaiction`.`id_num` AS `id_num`,`payrequest_notifaiction`.`date` AS `date`,`payrequest_notifaiction`.`my_name` AS `my_name`,`payrequest_notifaiction`.`recipient` AS `recipient`,`payrequest_notifaiction`.`recipient_name` AS `recipient_name` from `swiss_db`.`payrequest_notifaiction` order by `id_num` desc
md5=e77c926144535c06ebfa7b9fb758a1d1
updatable=0
algorithm=0
definer_user=root
definer_host=localhost
suid=2
with_check_option=0
timestamp=2021-12-13 10:07:55
create-version=2
source=SELECT `id_num`,`date`,`my_name`,`recipient`,`recipient_name` FROM chackreport_notification\nUNION\nSELECT `id_num`,`date`,`my_name`,`recipient`,`recipient_name` FROM addreturn_notification\nUNION\nSELECT `id_num`,`date`,`my_name`,`recipient`,`recipient_name` FROM paypart_notification\nUNION\nSELECT `id_num`,`date`,`my_name`,`recipient`,`recipient_name` FROM payrequest_notifaiction\nORDER BY id_num DESC
client_cs_name=utf8mb4
connection_cl_name=utf8mb4_unicode_ci
view_body_utf8=select `chackreport_notification`.`id_num` AS `id_num`,`chackreport_notification`.`date` AS `date`,`chackreport_notification`.`my_name` AS `my_name`,`chackreport_notification`.`recipient` AS `recipient`,`chackreport_notification`.`recipient_name` AS `recipient_name` from `swiss_db`.`chackreport_notification` union select `addreturn_notification`.`id_num` AS `id_num`,`addreturn_notification`.`date` AS `date`,`addreturn_notification`.`my_name` AS `my_name`,`addreturn_notification`.`recipient` AS `recipient`,`addreturn_notification`.`recipient_name` AS `recipient_name` from `swiss_db`.`addreturn_notification` union select `paypart_notification`.`id_num` AS `id_num`,`paypart_notification`.`date` AS `date`,`paypart_notification`.`my_name` AS `my_name`,`paypart_notification`.`recipient` AS `recipient`,`paypart_notification`.`recipient_name` AS `recipient_name` from `swiss_db`.`paypart_notification` union select `payrequest_notifaiction`.`id_num` AS `id_num`,`payrequest_notifaiction`.`date` AS `date`,`payrequest_notifaiction`.`my_name` AS `my_name`,`payrequest_notifaiction`.`recipient` AS `recipient`,`payrequest_notifaiction`.`recipient_name` AS `recipient_name` from `swiss_db`.`payrequest_notifaiction` order by `id_num` desc
mariadb-version=100419
