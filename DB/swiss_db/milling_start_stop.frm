TYPE=VIEW
query=select `swiss_db`.`data_operating_milling`.`date` AS `date`,`swiss_db`.`data_operating_milling`.`line` AS `line`,sec_to_time(sum(time_to_sec(`swiss_db`.`data_operating_milling`.`error_time`))) AS `Stop_Time_Work`,subtime(\'24:00:00\',sec_to_time(sum(time_to_sec(`swiss_db`.`data_operating_milling`.`error_time`)))) AS `Work_Time` from `swiss_db`.`data_operating_milling` group by `swiss_db`.`data_operating_milling`.`line`,`swiss_db`.`data_operating_milling`.`date` order by `swiss_db`.`data_operating_milling`.`date` desc
md5=3e2cce4e41da69e11785857e2e5a1b18
updatable=0
algorithm=0
definer_user=root
definer_host=localhost
suid=1
with_check_option=0
timestamp=2021-12-13 06:10:18
create-version=2
source=SELECT `data_operating_milling`.`date` AS `date`, `data_operating_milling`.`line` AS `line`, sec_to_time(sum(time_to_sec(`data_operating_milling`.`error_time`))) AS `Stop_Time_Work`, subtime(\'24:00:00\',sec_to_time(sum(time_to_sec(`data_operating_milling`.`error_time`)))) AS `Work_Time` FROM `data_operating_milling` GROUP BY `data_operating_milling`.`line`, `data_operating_milling`.`date` ORDER BY `data_operating_milling`.`date` DESC
client_cs_name=utf8mb4
connection_cl_name=utf8mb4_unicode_ci
view_body_utf8=select `swiss_db`.`data_operating_milling`.`date` AS `date`,`swiss_db`.`data_operating_milling`.`line` AS `line`,sec_to_time(sum(time_to_sec(`swiss_db`.`data_operating_milling`.`error_time`))) AS `Stop_Time_Work`,subtime(\'24:00:00\',sec_to_time(sum(time_to_sec(`swiss_db`.`data_operating_milling`.`error_time`)))) AS `Work_Time` from `swiss_db`.`data_operating_milling` group by `swiss_db`.`data_operating_milling`.`line`,`swiss_db`.`data_operating_milling`.`date` order by `swiss_db`.`data_operating_milling`.`date` desc
mariadb-version=100419
