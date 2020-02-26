SELECT ROW_NUMBER() OVER (Order by KODE) [NO], * FROM
(
select dt1_id KODE, dt1_nm PROPINSI, count(distinct dt2_id) KABUPATEN, count(distinct dt3_id) KECAMATAN, count(distinct dt4_id) KELURAHAN from
(
	select dt1.id dt1_id, dt1.nm dt1_nm, dt2.id dt2_id, dt2.nm dt2_nm, dt3.id dt3_id, dt3.nm dt3_nm  , dt4.id dt4_id, dt4.nm dt4_nm from dt1
	inner join dt2 
	on dt1.id = left(dt2.id,2)
	inner join dt3
	on dt2.id = left(dt3.id,5)
	inner join dt4
	on dt3.id = left(dt4.id,8)
)a
group by dt1_id, dt1_nm 
)S
union all
select '','', 'TOTAL NASIONAL',(select COUNT(id) from dt2),(select COUNT(id) from dt3),(select COUNT(id) from dt4)
order by KODE



